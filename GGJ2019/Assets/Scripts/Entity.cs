using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    [SerializeField]
    float hp;
    [SerializeField]
    int damage;
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpSpeed;

    public Rigidbody2D rigidbody2;
    
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    void TakeDamage(int amount)
    {
        hp -= amount;

        if (hp <= 0)
            Die();
    }

    public virtual void Die()
    {

    }

    public void Move(Vector2 direction)
    {
        Vector2 movementVector = new Vector2(Mathf.Clamp((direction.x * speed)+rigidbody2.velocity.x, -speed, speed), (direction.y * jumpSpeed)+rigidbody2.velocity.y);

        rigidbody2.velocity = movementVector;
    }
}
