using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public int playerLives;

	public int playerHealth;

	public void NewGame()
	{

		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		SceneManager.LoadScene(startLevel);
		
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth)	;

		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);

		//player lifes = PlayerCurrentLives
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}