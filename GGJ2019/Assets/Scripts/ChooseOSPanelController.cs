using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOSPanelController : PanelController
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			screenController.NextScreen();
		}
	}
}
