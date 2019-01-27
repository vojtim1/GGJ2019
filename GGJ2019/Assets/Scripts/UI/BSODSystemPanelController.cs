using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSODSystemPanelController : PanelController
{
	Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private bool pressed = false;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F) && !pressed)
		{
			animator.CrossFade("BSOD", 0f);
			pressed = true;
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Next"))
		{
			screenController.NextScreen();
		}
	}
}
