using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
	ScreenController screenController;

	public void SetScreenController(ScreenController screenController)
	{
		this.screenController = screenController;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Return))
		{
			screenController.NextScreen();
		}
	}
}
