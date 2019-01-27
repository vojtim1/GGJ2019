using UnityEngine;

public class Coins : PickUpObject
{
    public override void OnPickUp()
    {
        GameObject.FindGameObjectWithTag("Player").SendMessage("AddHealth", 2);
        Destroy(gameObject);
    }
}
