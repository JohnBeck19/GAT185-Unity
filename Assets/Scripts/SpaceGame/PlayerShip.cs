using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable
{
    [SerializeField] private PathFollower pathFollower;
    [SerializeField] private Inventory inventory;
    [SerializeField] private IntEvent ScoreEvent;
    [SerializeField] Action action;
    [SerializeField] IntVariable score;
    [SerializeField] private FloatVariable health;

    [SerializeField] protected GameObject hitPrefab;
    [SerializeField] protected GameObject destroyPrefab;

    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent PlayerDeadEvent = default;
    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] AudioClip pickupSound;
    float timer = 0;

    private void OnEnable()
    {
        gameStartEvent.Subscribe(onStartGame);
    }
    private void onStartGame()
    {
        pathFollower.speed = 40.0f;
        health.value = 100;

    }
    private void Start()
    {
        ScoreEvent.Subscribe(AddPoints);
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inventory.Use();

        }
        if (Input.GetButtonUp("Fire1"))
        {
            inventory.StopUse();
        }
        if (Time.time >= timer)
        {
            pathFollower.speed = (pathFollower.speed == 0) ? 0 : 40.0f;
        }
        Debug.Log(health.value + " Health");
    }
    public void AddPoints(int points)
    { 
        score.Value += points;
        
    }

    public void ApplyDamage(float damage)
    {
        health.value -= damage;
        if (health.value <= 0)
        {
            if (destroyPrefab != null)
            {
                Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
            }
            PlayerDeadEvent.RaiseEvent();
            Destroy(gameObject);
        }
        else
        {
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
            }
        }
    }

    public void ApplyHealth(float health) 
    {
        playerAudioSource.PlayOneShot(pickupSound);
        this.health.value += health;
        this.health.value = Mathf.Min(this.health.value,100); 
    }

    public void SpeedBuff()
    {
        playerAudioSource.PlayOneShot(pickupSound);
        timer = Time.time + 5;
        pathFollower.speed = 80.0f;
    }
}
