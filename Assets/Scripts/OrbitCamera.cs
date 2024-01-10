using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField][Range(20, 90)] float pitch = 40;
    [SerializeField][Range(1, 50)] float distance = 5;
    [SerializeField][Range(0.1f, 2.0f)] float sensitivity = 0.5f;

    float yaw = 0;

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;

        transform.position = target.position + (rotation * Vector3.back*distance);
        transform.rotation = rotation;
    }
}
