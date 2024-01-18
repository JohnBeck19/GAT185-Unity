using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;

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
    public float timer = 0;
    public int lives = 0;
    public int Lives {  get { return lives; } set { lives = value; livesUI.text = "LIVES "+lives.ToString(); } }
    public float Timer {  get { return timer; } set { timer = value; timerUI.text = timer.ToString("0.00"); } }

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
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
				break;
			case State.START_GAME:
                titleUI.SetActive(false);
                Timer = 60;
                Lives = 3;
                health.value = 100;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                state = State.PLAY_GAME;
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
				break;
			case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0)
                {
                    state = State.GAME_OVER;
                }
				break;
			case State.GAME_OVER:
				break;
		}
        healthUI.value = health.value / 100.0f;
	}
    public void OnStartGame()
    {
        state = State.START_GAME;
    }
	public void onPlayerDead()
	{
        state = State.TITLE;

	}
	public void OnAddPoints(int points)
    {
        print(points);
    }
}