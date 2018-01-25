using UnityEngine;
using System.Collections;

public class EnemyFireProjectile : MonoBehaviour {

	public float speed;

	public Player player;

	public GameObject impactEffect;

	public float rotationSpeed;

	public int damageToGive;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();

		rb2d = GetComponent<Rigidbody2D>();

		if (player.transform.position.x < 0) 
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(speed,rb2d.velocity.y);

		rb2d.angularVelocity = rotationSpeed;
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			PlayerHealthManager.HurtPlayer(damageToGive);
		}
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}