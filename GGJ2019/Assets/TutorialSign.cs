using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSign : MonoBehaviour
{
    bool checkForTrigger = true;
    [SerializeField]
    GameObject theMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8 && checkForTrigger)
        {
            theMessage.SetActive(true);
            checkForTrigger = false;
        }
    }
}
