﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : PanelController
{
    public void PlayButtonPressed()
	{
		screenController.NextScreen();
	}
}
