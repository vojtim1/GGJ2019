using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenu : PanelController
{
    public void ConfirmButtonPressed()
	{
        PlayerPrefs.SetString("SkipScreens", "True");
        screenController.NextScreen();
	}
}
