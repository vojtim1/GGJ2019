using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBars : MonoBehaviour
{
    [SerializeField]
    Image[] bars = new Image[4];
    GameObject player;

    float angle = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        bars[0].fillAmount = player.transform.parent.GetComponent<Player>().health / player.transform.parent.GetComponent<Player>().maxHealth;
        bars[1].fillAmount = 1;
        bars[2].fillAmount = Mathf.Abs(Mathf.Sin(angle));
        bars[3].fillAmount = .15f;

        angle += Time.deltaTime;
    }
}
