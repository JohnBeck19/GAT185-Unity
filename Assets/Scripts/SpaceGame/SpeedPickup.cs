using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerShip>(out PlayerShip player))
        {
            player.SpeedBuff();

            Destroy(gameObject);
        }
    }
}
