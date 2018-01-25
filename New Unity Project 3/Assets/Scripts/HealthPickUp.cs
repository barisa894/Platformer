using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
		public int healthtoAdd;
		void OnTriggerEnter2D (Collider2D other) 
		{
			if (other.GetComponent<Player> () == null) //for player to pick up the candies
				return;
			
			PlayerHealthManager.HurtPlayer(-healthtoAdd);
			
			Destroy (gameObject);
		}
	}
	
	
