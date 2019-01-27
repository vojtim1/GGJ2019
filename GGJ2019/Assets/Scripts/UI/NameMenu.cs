using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameMenu : PanelController
{
	[SerializeField]
	GameObject inputFieldObject;
	TMP_InputField inputField;
	[SerializeField]
	GameObject nameTakenText;

	string firstTry;
	bool tried;

	private void Start()
	{
		inputField = inputFieldObject.GetComponent<TMP_InputField>();
	}

	public void ConfirmButtonPressed()
	{
		string currentTry = inputField.text;
		if (!tried && currentTry != "")
		{
			firstTry = currentTry;
			tried = true;
		}

		if(firstTry == currentTry)
		{
			nameTakenText.SendMessage("Reappear");
		}
		else if(currentTry == "")
		{

		}
		else
		{
			screenController.NextScreen();
		}	
	}
	
}
