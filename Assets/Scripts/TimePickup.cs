using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    [SerializeField] GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.onTimerPickup(10.0f);

        Instantiate(pickupPrefab,transform.position,Quaternion.identity);

        Destroy(gameObject);
    }
}
