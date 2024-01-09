using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField][Range(1,20)] float force;
    Rigidbody rb;


    private void Awake()
    {
        print("awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        print("start");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(transform.up*force,ForceMode.VelocityChange);
        }
        
    }
}
