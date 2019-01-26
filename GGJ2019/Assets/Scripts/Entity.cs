using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    [SerializeField]
    float hp;

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
}
