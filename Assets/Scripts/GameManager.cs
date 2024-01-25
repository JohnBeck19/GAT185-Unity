using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject GameUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] TMP_Text ScoreUI;
    [SerializeField] Slider healthUI;
    [SerializeField] GameObject EndScreenUI;
    [SerializeField] TMP_Text finalScoreText;

    [SerializeField] FloatVariable health;
    [SerializeField] FloatVariable timer;
    [SerializeField] IntVariable lives;
    [SerializeField] IntVariable score;

    [SerializeField] GameObject respawn;
    [Header("Events")]
   // [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] GameObjectEvent respawnEvent;
    public enum State 
    { 
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }
    public State state = State.TITLE;
 
    public int Lives {  get { return lives.Value; } set { lives.Value = value; livesUI.text = "LIVES " + lives.Value.ToString(); } }
    public float Timer {  get { return timer.value; } set { timer.value = value; timerUI.text = timer.value.ToString("0.00"); } }

    // Start is called before the first frame update
    void Start()
    {
      //  scoreEvent.Subscribe(OnAddPoints);
    }

    // Update is called once per frame
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
                Lives = 3;
				break;
			case State.START_GAME:

                titleUI.SetActive(false);
                EndScreenUI.SetActive(false);
                GameUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Timer = 60;
                health.value = 100;
                state = State.PLAY_GAME;
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
				break;
			case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0)
                {
                    onPlayerDead();
                        
                }
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
        Lives = Lives - 1;
        if (Lives > 0) state = State.START_GAME;
        else state = state = State.GAME_OVER;

	}
	public void OnAddPoints(int points)
    {
        print(points);
    }
    public void onTimerPickup(float time)
    {
        Timer += time;
    }
}