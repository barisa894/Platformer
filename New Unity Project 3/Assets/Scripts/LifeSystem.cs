using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeSystem : MonoBehaviour {

	//public int startingLives;
	private int lifeCounter;

	private Text theText;

	public GameObject gameOverScreen;

	public Player player;

	public string mainMenu;

	public float waitAfterGameOver;

	// Use this for initialization
	void Start () {

		theText = GetComponent<Text> ();

		lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives"); //to retain the player lives between all levels

		player = FindObjectOfType<Player> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter < 0) 
		{
			gameOverScreen.SetActive(true); //gameover
			player.gameObject.SetActive(false); // player doesn't move
		}
		theText.text = " x " + lifeCounter;

		if (gameOverScreen.activeSelf) 
		{
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 0) 
		{
			SceneManager.LoadScene (mainMenu);
		}
	}

	public void GiveLife()
	{
		lifeCounter++;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}
	public void TakeLife()
	{
		lifeCounter--;
		Debug.Log ("Life's taken");
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}

	
}

