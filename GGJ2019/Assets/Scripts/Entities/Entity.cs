using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(AudioSource))]
public class Entity : MonoBehaviour
{
    [SerializeField]
    public float health;

    [SerializeField]
    public float maxHealth;

    [HideInInspector]
    public Rigidbody2D rigidbody2;

	protected AudioSource audioSource;

	[SerializeField]
	AudioClip damagedSound;
	[SerializeField]
	AudioClip diedSound;

    [SerializeField]
    List<string> unskipableAnimatorStates;

    protected virtual void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
        health = maxHealth;
    }

    void TakeDamage(int amount)
    {
		audioSource.PlayOneShot(damagedSound);
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
		audioSource.PlayOneShot(diedSound);
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
