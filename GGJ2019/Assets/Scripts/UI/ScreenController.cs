using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
	[SerializeField]
	private GameObject[] screens;
	private int currentScreen;

    void Start()
    {
        //PlayerPrefs.SetString("SkipScreens", "False");
        if (PlayerPrefs.GetString("SkipScreens") == "True")
        {
            gameObject.SetActive(false);
            return;
        }
        currentScreen = 0;
		for (int i = 0; i < screens.Length; i++)
		{
			screens[i].SendMessage("SetScreenController", this);
			screens[i].SetActive(false);
		}

		screens[currentScreen].SetActive(true);
    }

	[ContextMenu("Next Screen")]
	public void NextScreen()
	{
		screens[currentScreen].SetActive(false);
		currentScreen++;
		if(currentScreen < screens.Length)
		{
			screens[currentScreen].SetActive(true);
		}
	}
}
