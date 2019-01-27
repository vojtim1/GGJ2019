using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    [SerializeField]
    public float health;

    [SerializeField]
    public float maxHealth;

    [HideInInspector]
    public Rigidbody2D rigidbody2;

    [SerializeField]
    List<string> unskipableAnimatorStates;

    protected virtual void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
            return;
        }

        if (GetComponent<Animator>())
            GetComponent<Animator>().CrossFade("Take Damage", 0f);

    }

    public virtual void Die()
    {
        if (GetComponent<Animator>())
            GetComponent<Animator>().CrossFade("Die", 0f);
    }

    protected bool CanSkip()
    {
        Animator animator = GetComponent<Animator>();
        foreach (string stateName in unskipableAnimatorStates)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
                return false;
        }
        return true;
    }
}
