using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {


	public float speed;

	public Rigidbody2D rb2d;
	public Player player;

	//public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	public float rotationSpeed;

	public int damageToGive;

	public int pointsForKill;

	//private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		//rb2d = FindObjectOfType<Rigidbody2D> ();
		rb2d = GetComponent<Rigidbody2D>();

		if (player.transform.localScale.x < 0) 
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
		if (other.tag == "Enemy")
		{
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointsForKill);

			other.GetComponent<EnemyHealth> ().giveDamage (damageToGive);
		}
		if (other.tag == "The Boss") {
			other.GetComponent<BossHealthManager> ().giveDamage (damageToGive);
		}

		//Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}