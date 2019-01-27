using UnityEngine;

public class Coins : PickUpObject
{
	AudioSource audioSource;
	[SerializeField]
	AudioClip pickupSound;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public override void OnPickUp()
    {
		audioSource.PlayOneShot(pickupSound);
		FindObjectOfType<Player>().AddHealth(5);
		transform.position = new Vector2(0, 1000);
    }
}
