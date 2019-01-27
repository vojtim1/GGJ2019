using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F5) && Input.GetKey(KeyCode.Keypad1) &&
			Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.I))
		{
			Application.Quit();
			Debug.Log("exit");
		}
	}
}
