using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stat : MonoBehaviour
{
	[SerializeField]
	GameObject textFieldObject;
	TextMeshProUGUI textField;

	[SerializeField]
	private int value;
	[SerializeField]
	private int minValue;
	[SerializeField]
	private int maxValue;

	private void Start()
	{
		textField = textFieldObject.GetComponent<TextMeshProUGUI>();
		textField.text = "" + value;
	}

	public void Add()
	{
		if(value >= maxValue)
		{

		}
		else
		{
			value++;
			textField.text = "" + value;
		}
	}

	public void Remove()
	{
		if(value <= minValue)
		{

		}
		else
		{
			value--;
			textField.text = "" + value;
		}
	}
}
