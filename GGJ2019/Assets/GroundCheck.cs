using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool grounded = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
            grounded = true;
        else grounded = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
            grounded = false;
    }
}
