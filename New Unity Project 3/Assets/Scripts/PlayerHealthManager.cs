using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {
	
	public int maxHealth;
	
	public static int playerHealth;

	private Player player;
	private LifeSystem lifeSystem;
	
	//Text text;

	public Slider healthBar;
	
	private LevelManager levelManager;

	public bool isDead;
	// Use this for initialization
	void Start () {
	//	text = GetComponent<Text> ();

		healthBar = GetComponent<Slider> ();
		
		playerHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth"); //to retain the player health between all levels

		lifeSystem = FindObjectOfType<LifeSystem> ();
		
		levelManager = FindObjectOfType<LevelManager> ();

		isDead = false;
	}
	
	void Update()
	{
		if(playerHealth <= 0 && !isDead )
		{
			playerHealth = 0;
			Debug.Log ("player is dead");
			levelManager.RespawnPlayer();
			lifeSystem.TakeLife();
			isDead = true;

		}

		if (playerHealth > maxHealth)
			playerHealth = maxHealth;
		//text.text = "" + playerHealth;

		healthBar.value = playerHealth;
	}
		
	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}
	
	public void FullHealth()
	{
		isDead = false;
		playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	//public void KillPlayer()
	//{
	//	playerHealth = 0;
	//}
}
