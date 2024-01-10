using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force = Vector3.zero;
    [SerializeField][Range(1, 100)] float maxForce = 10;
    [SerializeField][Range(1, 100)] float jumpForce = 10;
    [SerializeField] Transform view;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        force = view.rotation * direction * maxForce;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }
	private void FixedUpdate()
	{
        rb.AddForce(force,ForceMode.Force);
	}
}
