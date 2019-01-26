﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy settings")]
    [SerializeField]
    float agroDistance; //Starts chasing
    [SerializeField]
    float letGoDistance; //Stops chasing
    [SerializeField]
    float attackDistance; //Stops and attacks
    EnemyStatus enemyStatus = EnemyStatus.IDLE;

    Transform player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Update()
    {
        base.Update();
        float distance = Distance(transform, player);
        if(enemyStatus == EnemyStatus.IDLE)
        {
            if (distance <= agroDistance)
                enemyStatus = EnemyStatus.CHASING;
            //DO IDLE ANIMATION
        }
        if(enemyStatus == EnemyStatus.CHASING)
        {
            if (distance >= letGoDistance)
                enemyStatus = EnemyStatus.IDLE;
            if (distance <= attackDistance*0.8f)
                enemyStatus = EnemyStatus.ATTACKING;
            Chase();
        }
        if(enemyStatus == EnemyStatus.ATTACKING)
        {
            if (distance >= attackDistance)
                enemyStatus = EnemyStatus.CHASING;
            Attack(player.position);
        }
    }

    void Chase()
    {
        bool playerIsLeft = true;
        if (player.position.x < transform.position.x)
            playerIsLeft = true;
        else playerIsLeft = false;
        //MOVE TO PLAYER
        Vector2 moveVector;
        if (playerIsLeft)
            moveVector = Vector2.left;
        else moveVector = Vector2.right;
        Move(moveVector);
        //CHECK FOR OBSTACLE ***ONLY IF NOT ON FLATLAND***

        //ROTATE TOWARDS PLAYER
        //ANIMATE
    }

    float Distance(Transform transform1, Transform transform2)
    {
        return Vector2.Distance(transform1.position, transform2.position);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
