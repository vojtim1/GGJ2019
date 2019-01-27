using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisappearingText : MonoBehaviour
{
	TextMeshProUGUI text;

	private void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
		text.faceColor = new Color32(255, 0, 0, 0);
	}

	private float counter;
	private float secondsToDisappear = 1;
	public void Update()
	{
		if(text.faceColor.a < 5)
		{
			counter = 0;
			text.faceColor = new Color32(255, 0, 0, 0);
		}
		else
		{
			counter += Time.deltaTime;
			if(counter > 1)
			{
				byte alpha = (byte)(255 - counter / secondsToDisappear * 255);
				text.faceColor = new Color32(255, 0, 0, alpha);
			}
		}
	}

	public void Reappear()
	{
		text.faceColor = new Color32(255, 0, 0, 255);
		counter = 0;
	}
}
