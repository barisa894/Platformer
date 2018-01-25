using UnityEngine;
using System.Collections;

public class LifePickUp : MonoBehaviour {

	private LifeSystem lifeSystem;

	void Start()
	{
		lifeSystem = FindObjectOfType<LifeSystem> ();
	}
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.GetComponent<Player> () == null) //for player to pick up the candies
			return;
		
		lifeSystem.GiveLife ();
		
		Destroy (gameObject);
	}
}

