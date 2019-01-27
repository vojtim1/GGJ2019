using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSODContainer : PanelController
{
	[SerializeField]
	GameObject bsodPanel;

	public override void SetScreenController(ScreenController screenController)
	{
		bsodPanel.SendMessage("SetScreenController", screenController);
	}
}
