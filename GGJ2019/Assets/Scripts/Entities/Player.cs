using UnityEngine;

public class Player : Character
{
	[SerializeField]
	AudioClip jumpSound;

    [SerializeField]
    bool hasDoubleJump = false;
    [SerializeField]
    bool doubleJump = false;

    bool isAlive = true;

    protected override void Update()
    {
        if (isAlive)
        {
            base.Update();
            Move(GetDirectionVector());
            if (Input.GetKeyDown(KeyCode.Space))
                Attack(new Vector2(transform.position.x + 1, 0));
            if(Input.GetKeyDown(KeyCode.S))
            {
                RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, maxGroundDistance);
                if (hit2D.transform)
                    if (hit2D.transform.GetComponent<Platform>())
                        hit2D.transform.SendMessage("DisablePlatform", 1);
            }
        }
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
            {
                directionVector += new Vector2(0, 1);
                audioSource.PlayOneShot(jumpSound);
            }
            else if (doubleJump && hasDoubleJump) { directionVector += new Vector2(0, 1); doubleJump = false; audioSource.PlayOneShot(jumpSound); }
        return directionVector;
    }

    public override void Die()
    {
        base.Die();
        isAlive = false;
        print("You died.");
    }

	public void AddHealth(int health)
	{
		this.health += health;
        if (this.health > maxHealth)
            this.health = maxHealth;
	}

    void AcquireDoubleJump()
    {
        hasDoubleJump = true;
        doubleJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            doubleJump = true;
    }
}
