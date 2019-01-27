using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    BoxCollider2D boxCollider;
    float timeToEnable;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        timeToEnable -= Time.deltaTime;
        if(timeToEnable <= 0)
        {
            boxCollider.enabled = true;
        }
    }

    void DisablePlatform(float time)
    {
        timeToEnable = time;
        boxCollider.enabled = false;
    }
}
