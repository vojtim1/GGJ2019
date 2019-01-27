using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableObject : MonoBehaviour
{
    [SerializeField]
    bool toggleSelf = false; //E.G. change sprite on toggle
    [SerializeField]
    bool isActivator = false; //Can be activated by pressing "E" directly or by some other object?
    [SerializeField]
    protected bool isActivated = false;
    [SerializeField]
    List<GameObject> gameObjectsToToggle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (isActivator)
            {
                print("Press 'E' to pull the lever.");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (isActivator)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //print("Activating");
                    Toggle();
                }
            }
        }
    }

    void Toggle()
    {
        if (toggleSelf)
            OnToggle();
        foreach (GameObject go in gameObjectsToToggle)
        {
            go.SendMessage("OnToggle");
        }
    }

    public virtual void OnToggle()
    {
        print("toggling");
        isActivated = !isActivated;
    }
}
