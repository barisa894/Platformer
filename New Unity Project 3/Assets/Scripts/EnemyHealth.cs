﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public int enemyHealth;
	
	public int damageToGive;
	public int pointsOnDeath;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) 
		{
			ScoreManager.AddPoints(pointsOnDeath);
			Destroy (gameObject);
		}
		
	}
	public void giveDamage (int damageToGive){
		enemyHealth -= damageToGive;
	}
}
