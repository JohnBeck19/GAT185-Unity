using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force = Vector3.zero;
    [Header("Movement")]
    [SerializeField][Range(1, 100)] float maxForce = 10;
    [SerializeField][Range(1, 100)] float jumpForce = 10;
    [SerializeField] Transform view;
    [Header("Collision")]
    [SerializeField] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip roll;
    

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

        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);

        force = yrotation * direction * maxForce;
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        if (Input.GetButtonDown("Jump") && checkGround())
        {
            playerAudioSource.PlayOneShot(jump);
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
        if (rb.velocity != Vector3.zero && checkGround() == true)
        {
            float mag = rb.velocity.magnitude * 0.1f;
            playerAudioSource.volume = (mag > 0.75f) ? 0.75f : mag;
           if (!playerAudioSource.isPlaying) playerAudioSource.PlayOneShot(roll);
        }
        else {
           // playerAudioSource.Pause();
        }
    }
	private void FixedUpdate()
	{
        rb.AddForce(force,ForceMode.Force);
	}

    private bool checkGround()
    {

        return Physics.Raycast(transform.position, Vector3.down, rayLength,groundLayerMask);
    }
	public void Reset()
	{
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
	}
}
