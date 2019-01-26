using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ActivableObjectWithCollider : SpriteChangingObject
{
    Collider2D localCollider;

    private void Start()
    {
        localCollider = GetComponent<Collider2D>();
    }

    public override void OnToggle()
    {
        base.OnToggle();
        if (isActivated)
            localCollider.enabled = false;
        else localCollider.enabled = true;
    }
}
