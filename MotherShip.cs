﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MotherShip : MonoBehaviour 
{
	public int collectedEnergy = 0;
	public int neededEnergy;

	public GameObject[] energy;
	public int totalEnergy;

	public float difficultyPercentage = 0.5f;
	
	private PlayerInventory playerInventory;

	private Animator anim;
	public float restartDelay = 3f;
	private float restartTimer;

    public bool gamelost = false;
    public bool gameWon = false;

	
	void Start()
	{
		playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
		energy = GameObject.FindGameObjectsWithTag("Energy");
		totalEnergy = energy.Length;
		//neededEnergy = Mathf.RoundToInt (totalEnergy * difficultyPercentage);
		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
		StartCoroutine(waitThenDoMath());
	}

	IEnumerator waitThenDoMath()
	{
		yield return new WaitForSeconds(1);
		neededEnergy = Mathf.RoundToInt (totalEnergy * difficultyPercentage);
	}

	void Update()
	{
		if(totalEnergy < neededEnergy)
		{
			//print ("Game Over!");
			anim.SetTrigger("IsGameOver");

			restartTimer+= Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
			    //gamelost = true;
				Application.LoadLevel(Application.loadedLevel);
			}

		}

		if(collectedEnergy == neededEnergy)
		{
			//print ("Game Over!");
			anim.SetTrigger("IsGameWon");

			restartTimer+= Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
			    gameWon = true;
				//Application.LoadLevel(Application.loadedLevel);
			}

		}
	}
 
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//Take collected count and add it to the energy of the reactor, then reset the players collected energy to zero
			if(playerInventory.collectedEnergy != 0)
			{
				collectedEnergy += playerInventory.collectedEnergy;
				playerInventory.collectedEnergy = 0;
			}
			//Need ten to win the game.
			//if(collectedEnergy == neededEnergy)
			//{
			//	print ("You win!");
			//}
			
		}
	}
}
