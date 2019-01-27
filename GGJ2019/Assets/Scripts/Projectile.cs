using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Entity>())
        {
            collision.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Entity>())
        {
            collision.gameObject.SendMessage("TakeDamage", damage);
        }
        Destroy(gameObject);
    }
}
