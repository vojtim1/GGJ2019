using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    [SerializeField]
    int damage;
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    protected float maxGroundDistance;

	[SerializeField]
	AudioClip meleeSound;
	[SerializeField]
	AudioClip shootSound;

    [SerializeField]
    bool melee = false;
    [SerializeField]
    float attackSpeed; //HOW MANY TIMES A SECOND CAN THIS CHARACTER ATTACK?
    [SerializeField]
    float nextAttack = 0;
    [SerializeField]
    float meleeRange = 4;
    [SerializeField]
    LayerMask layer;

    [Header("Shooting")]
    [SerializeField]
    float bulletSpawnDistance;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float bulletSpeed;

    bool muzzleFlashEnabled = false;
    GameObject tempMuzzleFlash;

    protected virtual void Update()
    {
        nextAttack -= Time.deltaTime;

        if (muzzleFlashEnabled)
        {
            tempMuzzleFlash.SetActive(false);
            muzzleFlashEnabled = false;
        }
    }

    public void Move(Vector2 direction)
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            if (CanSkip())
            {
                if (direction.magnitude != 0)
                {
                    if (direction.x < 0)
                        animator.CrossFade("Walk Backward", 0f);
                    else animator.CrossFade("Walk", 0f);
                }
                else
                    animator.CrossFade("Idle", 0f);
            }
        }

        Vector2 movementVector = new Vector2(Mathf.Clamp((direction.x * speed) + rigidbody2.velocity.x, -speed, speed), (direction.y * jumpSpeed) + rigidbody2.velocity.y);

        if (direction.x == 0)
            movementVector.x = 0;

        rigidbody2.velocity = movementVector;
    }

    public void ShootAt(Vector2 targetPosition)
    {
        Vector2 direction = GetDirection(transform.position, targetPosition);
        Vector2 normalSpeedDirection = (bulletSpawnDistance / direction.magnitude) * direction;
        Vector2 spawnPos = normalSpeedDirection + (Vector2)transform.position;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(Vector2.zero));
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * normalSpeedDirection;

        if (GetComponent<Animator>())
            GetComponent<Animator>().CrossFade("Attack", 0f);
    }

    public void ShootAt(Vector2 targetPosition, Vector2 spawnPosition)
    {
		audioSource.PlayOneShot(shootSound);
		Vector2 direction = GetDirection(transform.position, targetPosition);
        Vector2 normalSpeedDirection = (bulletSpawnDistance / direction.magnitude) * direction;
        Vector2 spawnPos = spawnPosition;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(Vector2.zero));
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * normalSpeedDirection;

        if (GetComponent<Animator>())
            GetComponent<Animator>().CrossFade("Attack", 0f);
    }

    public Vector2 GetDirection(Vector2 objectPosition, Vector2 targetPosition)
    {
        return targetPosition - objectPosition;
    }

    protected bool GroundCheck()
    {
        if (GetComponentInChildren<GroundCheck>().grounded)
        {
            return true;
        }
        else return false;
    }

    protected void Attack(Vector2 targetPosition)
    {
        if (nextAttack <= 0)
        {
            if (melee)
            {
                MeleeeAttack(targetPosition);
            }
            else ShootAt(targetPosition);

            nextAttack = 1 / attackSpeed;
        }
    }

    protected void Attack(Vector2 targetPosition, GameObject muzzleExit)
    {
        if (nextAttack <= 0)
        {
            if (melee)
            {
                MeleeeAttack(targetPosition);
            }
            else
            {
                muzzleExit.transform.GetChild(0).gameObject.SetActive(true);
                tempMuzzleFlash = muzzleExit.transform.GetChild(0).gameObject;
                muzzleFlashEnabled = true;
                ShootAt(targetPosition, muzzleExit.transform.position);
            }

            nextAttack = 1 / attackSpeed;
        }
    }

    protected void MeleeeAttack(Vector2 targetPosition)
    {
		audioSource.PlayOneShot(meleeSound);
		Vector2 direction;
        if (targetPosition.x > transform.position.x)
            direction = Vector2.right;
        else direction = Vector2.left;

        if (GetComponent<Animator>())
            GetComponent<Animator>().CrossFade("Attack", 0f);

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, meleeRange, layer);
        if (hit2D.transform == null)
            return;
        if (hit2D.transform.GetComponent<Entity>())
            hit2D.transform.SendMessage("TakeDamage", damage);

    }

    public override void Die()
    {
        base.Die();
    }
}
