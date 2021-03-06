﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOnEnter : MonoBehaviour
{
    [SerializeField]
    string text;
    [SerializeField]
    float time;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
            FindObjectOfType<TextBubble>().Say(text, time);
    }
}
