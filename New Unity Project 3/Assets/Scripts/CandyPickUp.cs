using UnityEngine;
using System.Collections;

public class CandyPickUp : MonoBehaviour
{
	    public int pointstoAdd;
	    
		public AudioSource candySoundEffect;
		
		void OnTriggerEnter2D (Collider2D other) 
		{
			if (other.GetComponent<Player> () == null) //for player to pick up the candies
				return;
			
			ScoreManager.AddPoints(pointstoAdd);
		candySoundEffect.Play ();
			
			Destroy (gameObject);
		}
}


