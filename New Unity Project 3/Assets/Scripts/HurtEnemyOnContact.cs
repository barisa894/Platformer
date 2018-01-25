using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {

	public int damageToGive;

	public float bounceOnEnemy;

	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		rb2d = transform.parent.GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth> ().giveDamage (damageToGive);
			rb2d.velocity = new Vector2 (rb2d.velocity.x, bounceOnEnemy);
		}
		if (other.tag == "The Boss") {
			other.GetComponent<BossHealthManager> ().giveDamage (damageToGive);
			rb2d.velocity = new Vector2 (rb2d.velocity.x, bounceOnEnemy);
		}
	}
}

