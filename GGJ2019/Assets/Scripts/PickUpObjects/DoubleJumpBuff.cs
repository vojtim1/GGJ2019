using UnityEngine;

public class DoubleJumpBuff : PickUpObject
{
    public override void OnPickUp()
    {
        FindObjectOfType<Player>().SendMessage("AcquireDoubleJump");
        FindObjectOfType<TextBubble>().Say("Uh, double jump, sweet!", 2);
        Destroy(gameObject);
    }
}
