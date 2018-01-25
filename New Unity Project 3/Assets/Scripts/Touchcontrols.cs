using UnityEngine;
using System.Collections;

public class Touchcontrols : MonoBehaviour {

	private Player thePlayer;
	
	private LevelLoader levelExit;

	private PauseMenu thePauseMenu;


	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<Player> ();
		levelExit = FindObjectOfType<LevelLoader>();

		thePauseMenu = FindObjectOfType<PauseMenu> ();
		Debug.Log (levelExit);
	
	}
	
	// Update is called once per frame

	public void LeftController()
	{
		Debug.Log ("Left button clicked");
		thePlayer.Move (-1);
	
	}
	//public void DownController()
	//{
	//	Debug.Log ("Slide clicked");
	//	thePlayer.Slide();
	//}
	public void RightController()
	{
		thePlayer.Move (1);	}

	public void UnpressedArrow()
	{
		thePlayer.Move (0);
	}

	public void Star()
	{
		thePlayer.FireStar ();
	}

	public void Jump()
	{
		thePlayer.Jump ();

		if (levelExit.playerInZone) 
		{
			levelExit.LoadLevel();
		}
		if (thePlayer.onLadder) 
		{
			thePlayer.Jump ();
		}
	}

	public void Pause()
	{
		//Debug.Log ("Paused");
		thePauseMenu.PauseUnpause ();

		//thePauseMenu.isPaused = !thePauseMenu.isPaused;
	}
}
