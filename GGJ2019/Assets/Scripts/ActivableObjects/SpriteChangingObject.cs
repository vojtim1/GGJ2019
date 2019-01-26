using UnityEngine;

public class SpriteChangingObject : ActivableObject
{
    [Header("Sprite changing")]
    [SerializeField]
    Sprite defaultSprite;
    [SerializeField]
    Sprite otherSprite;

    public override void OnToggle()
    {
        base.OnToggle();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (isActivated)
            spriteRenderer.sprite = otherSprite;
        else spriteRenderer.sprite = defaultSprite;
    }
}
