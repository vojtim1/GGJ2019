public class BulletOnGround : PickUpObject
{
    public override void OnPickUp()
    {
        print("Adding ammo...");
        Destroy(gameObject);
    }
}
