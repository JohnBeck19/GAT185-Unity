using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour, IDamagable
{
	[SerializeField, Range(0, 40)] float speed = 1;
	[SerializeField, Range(0, 40)] float RotationAngle = 10;
	[SerializeField, Range(0, 40)] float RotationRate = 10;
	[SerializeField] float maxDistance = 5;
	[SerializeField] FloatVariable health;
	[SerializeField] PlayerShip player;


    void Update()
	{

		Vector3 direction = Vector3.zero;

		direction.x = Input.GetAxis("Horizontal");
		direction.y = Input.GetAxis("Vertical");

		Vector3 force = direction * speed * Time.deltaTime;
		transform.localPosition += force;

		transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);
		Quaternion qyaw = Quaternion.AngleAxis(direction.x *RotationAngle, Vector3.up);
		Quaternion qpitch = Quaternion.AngleAxis(direction.y *RotationAngle, Vector3.right);
		Quaternion rotation = qyaw * qpitch;
		transform.localRotation = Quaternion.Slerp(transform.localRotation,rotation,Time.deltaTime*RotationRate);
	}
    public void ApplyDamage(float damage)
    {
        player.ApplyDamage(damage);
    }
}
