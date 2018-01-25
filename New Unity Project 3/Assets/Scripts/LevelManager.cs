using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public GameObject currentCheckpoint;
	public int pointPenaltyOnDeath;
	private Player player;
	public PlayerHealthManager healthManager;
	public float respawnDelay;

	public GameObject deathParticle;

	public GameObject respawnParticle;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		healthManager = FindObjectOfType<PlayerHealthManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo()
	{
		
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		//player.GetComponent<Renderer>().enabled;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds(respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		//player.GetComponent<Renderer>().enabled;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);


		player.enabled = true;

		healthManager.FullHealth ();
	
	}
}

