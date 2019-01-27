using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
	protected ScreenController screenController;

	public virtual void SetScreenController(ScreenController screenController)
	{
		this.screenController = screenController;
	}
}
