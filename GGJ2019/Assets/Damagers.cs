using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagers : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.GetComponentInChildren<Entity>())
			collision.gameObject.SendMessage("TakeDamage", 10);
	}
}
