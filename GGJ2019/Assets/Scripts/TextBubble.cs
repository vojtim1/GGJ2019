using UnityEngine.UI;
using UnityEngine;

public class TextBubble : MonoBehaviour {
    public GameObject textBubble;

    public void Say(string text, float time)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        text = text.Replace("\\n", "\n");
        GetComponentInChildren<Text>().text = text;
        GetComponentInChildren<SelfDestruction>().time = time;
    }
}