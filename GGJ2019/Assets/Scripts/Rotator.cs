using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField]
	private float rotationSpeed;

	void Update()
	{
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotationSpeed);
	}

	public void SetRotationSpeed(float rotationSpeed)
	{
		this.rotationSpeed = rotationSpeed;
	}
}
