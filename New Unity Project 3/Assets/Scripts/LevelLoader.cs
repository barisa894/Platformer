using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	
	public bool playerInZone;

	public string leveltoLoad;
	//public AudioSource theDoorOpened;
	
	// Use this for initialization
	void Start () {
		playerInZone = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Vertical") > 0 && playerInZone) {
			
		SceneManager.LoadScene (leveltoLoad);
		}
	}
	public void LoadLevel()
		{
		SceneManager.LoadScene (leveltoLoad);
		}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			playerInZone = true;
			
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		playerInZone = false;
	}
}
