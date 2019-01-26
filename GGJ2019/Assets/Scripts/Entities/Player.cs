using UnityEngine;

public class Player : Character
{
    protected override void Update()
    {
        base.Update();
        Move(GetDirectionVector());
        if (Input.GetKeyDown(KeyCode.Space))
            Attack(new Vector2(transform.position.x + 1, 0));
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
            if (GroundCheck())
                directionVector += new Vector2(0, 1);
        return directionVector;
    }

    public override void Die()
    {
        base.Die();
        print("You died.");
    }
}
