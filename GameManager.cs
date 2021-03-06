﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private bool gameEnded = false;
    void Update()
    {
		if (gameEnded)	
			return;	

        if(PlayerStats.Lives <= 0)
		{
			endGame();
		}
    }

	void endGame()
	{
		gameEnded = true;
		Debug.Log("Game over!");
	}
}
