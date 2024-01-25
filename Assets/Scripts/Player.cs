using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [SerializeField] IntVariable score;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;


    public int Score { 
        get { return score.Value; }  
        set { 
            score.Value = value; 
            scoreText.text = score.Value.ToString(); 
            scoreEvent.RaiseEvent(score.Value);
        } 
    
    }


	private void OnEnable()
	{
        gameStartEvent.Subscribe(onStartGame);
	}

	public void AddPoints(int points)
    {
        Score += points;
    }
	public void Start()
	{
        health.value = 50.0f;
        characterController.enabled = false;
    }
    private void onStartGame()
    { 
        characterController.enabled = true;

    }

    public void onRespawn(GameObject respawn)
    { 
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        characterController.Reset(); 
    }
    public void Damage(float damage)
    {
        health.value -= damage;
        if (health.value <= 0)
        {
            playerDeadEvent.RaiseEvent();
            finalScoreText.text = Score.ToString();
        }
    }
}
