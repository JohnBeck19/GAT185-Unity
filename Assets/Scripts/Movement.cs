using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField][Range(-360, 360)] float angle = 10;
    float accelerate = 0;
    Rigidbody rb;

    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (accelerate < 25) accelerate += 3 * Time.deltaTime;
            transform.position += transform.forward * accelerate * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation *= Quaternion.AngleAxis(-angle * accelerate * Time.deltaTime, Vector3.up);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation *= Quaternion.AngleAxis(angle * accelerate * Time.deltaTime, Vector3.up);
            }
        }
        else {
            accelerate = 0;
        }

    }

}
