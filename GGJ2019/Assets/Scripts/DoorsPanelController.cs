using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsPanelController : PanelController
{
	float currentTime = 0;
	[SerializeField]
	AudioSource audioSource;
	[SerializeField]
	AudioClip quickDoors;
	[SerializeField]
	AudioClip windows;

	[SerializeField]
	GameObject doors;

	private bool switcher = false;
	private bool switcher2 = false;
	private bool switcher3 = false;

	void Update()
	{
		currentTime += Time.deltaTime;

		if(currentTime > 2 && !switcher)
		{
			audioSource.clip = quickDoors;
			audioSource.Play();
			doors.SendMessage("SetRotationSpeed", -200f);
			switcher = true;
		}

		if(currentTime > 4 && !switcher2)
		{
			audioSource.clip = windows;
			audioSource.Play();
			switcher2 = true;
		}

		if(currentTime > 6 && !switcher3)
		{
			audioSource.Stop();
			screenController.NextScreen();
			switcher3 = true;
		}
	}
}
