using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Transform enemyPrefab;
	public Transform spawnpoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	private int waveNumber = 0;

	void Update()
	{
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;

		
	}

	IEnumerator SpawnWave()
	{
		if(waveNumber < 10)
		{ 

		for(int i = 0; i < waveNumber; i++)
		{
			spawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}

		waveNumber++;
		}
	}

	void spawnEnemy()
	{
		Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
	}
}
