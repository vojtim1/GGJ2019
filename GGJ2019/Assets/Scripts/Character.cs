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

    [Header("Shooting")]
    [SerializeField]
    float bulletSpawnDistance;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float bulletSpeed;

    public void Move(Vector2 direction)
    {
        Vector2 movementVector = new Vector2(Mathf.Clamp((direction.x * speed) + rigidbody2.velocity.x, -speed, speed), (direction.y * jumpSpeed) + rigidbody2.velocity.y);

        rigidbody2.velocity = movementVector;
    }

    public void ShootAt(Vector2 targetPosition)
    {
        Vector2 direction = GetDirection(transform.position, targetPosition);
        Vector2 normalSpeedDirection = (bulletSpawnDistance / direction.magnitude) * direction;
        Vector2 spawnPos = normalSpeedDirection + (Vector2)transform.position;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(Vector2.zero));
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * normalSpeedDirection;
    }

    void Fire()
    {
        
    }

    public Vector2 GetDirection(Vector2 objectPosition, Vector2 targetPosition)
    {
        return targetPosition - objectPosition;
    }
}
