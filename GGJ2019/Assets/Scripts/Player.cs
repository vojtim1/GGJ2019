﻿using UnityEngine;

public class Player : Entity
{
    private void Update()
    {
        Move(GetDirectionVector());
    }

    bool IsGettingMovementInput()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && !Input.GetKeyDown(KeyCode.W))
            return false;
        else return true;
    }

    Vector2 GetDirectionVector()
    {
        Vector2 directionVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (Input.GetKeyDown(KeyCode.W))
            directionVector += new Vector2(0, 1);
        return directionVector;
    }

    public override void Die()
    {
        print("You died.");
    }
}