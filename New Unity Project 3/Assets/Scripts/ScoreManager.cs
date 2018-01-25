using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public static int score; //create score variable

	
	Text text;
	
	// Use this for initialization
	void Start () 
	{
		text = GetComponent<Text> ();
		
		//score = 0;

		score = PlayerPrefs.GetInt ("CurrentPlayerScore"); //to retain the player health between all levels
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (score < 0)
			score = 0;
		
		text.text = "" + score;
	}
	
	public static void AddPoints (int pointstoAdd) //add points to player
	{
		score += pointstoAdd;
		PlayerPrefs.SetInt ("CurrentPlayerScore", score);
	}
	public static void Reset() //when the player dies
	{
		score = 0;
		PlayerPrefs.SetInt ("CurrentPlayerScore", score);
	}
}
