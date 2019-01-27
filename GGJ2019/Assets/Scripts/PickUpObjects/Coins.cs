using UnityEngine;

public class Coins : PickUpObject
{
    public override void OnPickUp()
    {
		FindObjectOfType<Player>().AddHealth(5);
        Destroy(gameObject);
    }
}
