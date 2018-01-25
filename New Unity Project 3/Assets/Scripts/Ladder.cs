using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	private Player player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			player.onLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			player.onLadder = false;
		}
	}
	void Update () {
	
	}
}
