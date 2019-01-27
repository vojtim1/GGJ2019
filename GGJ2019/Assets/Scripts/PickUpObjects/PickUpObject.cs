using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PickUpObject : MonoBehaviour
{
    [SerializeField]
    string displayName;

    //private void OnMouseOver()
    //{
    //    print("Press RMB to pick up " + displayName);
    //    if(Input.GetKeyDown(KeyCode.Mouse1))
    //    {
    //        OnPickUp();
    //    }
    //}

    public virtual void OnPickUp()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            OnPickUp();
        }
    }
}
