using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject GameUI;
    [SerializeField] TMP_Text ScoreUI;
    [SerializeField] Slider healthUI;
    [SerializeField] GameObject EndScreenUI;
    [SerializeField] TMP_Text finalScoreText;

    [SerializeField] FloatVariable health;
    [SerializeField] IntVariable score;

    [Header("Events")]
    [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] VoidEvent playerDeadEvent;
    public enum State 
    { 
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }
    public State state = State.TITLE;
  

    void Start()
    {
        scoreEvent.Subscribe(OnAddPoints);
        playerDeadEvent.Subscribe(onPlayerDead);
    }

    void Update()
    {
		switch (state)
		{
			case State.TITLE:
                titleUI.SetActive(true);
                EndScreenUI.SetActive(false);
                GameUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
				break;
			case State.START_GAME:

                titleUI.SetActive(false);
                EndScreenUI.SetActive(false);
                GameUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                state = State.PLAY_GAME;
                gameStartEvent.RaiseEvent();
				break;
			case State.PLAY_GAME:

				break;
			case State.GAME_OVER:
                EndScreenUI.SetActive(true);
                GameUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                break;
		}
        healthUI.value = health.value / 100.0f;
	}
    public void OnStartGame()
    {
        state = State.START_GAME;
    }
    public void OnPlayAgain()
    {
        print("play again");
        state = State.TITLE;
    }
    public void onPlayerDead()
	{
        finalScoreText.text = ScoreUI.text;
        state = State.GAME_OVER;

	}
	public void OnAddPoints(int points)
    {
        ScoreUI.text = score.Value.ToString();
    }
}