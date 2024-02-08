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
        pathFollower.speed = (Input.GetKey(KeyCode.Space)) ? 80.0f : 40.0f;   
    }
    public void AddPoints(int points)
    { 
        score.Value += points;
        Debug.Log(score.Value);
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
        this.health.value += health;
        this.health.value = Mathf.Min(health,100); 
    }
}
