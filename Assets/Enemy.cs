using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	float lastBulletSpawned = 0;
	GameObject spawnedBullet;

	// Use this for initialization
	void Start () {

	}

	void Update()
	{
		if (Time.time - lastBulletSpawned >= 1 / GameController.gameController.bulletSpwanSpeed && Random.Range(0,1000) < 1)
		{
			spawnedBullet = Instantiate(GameController.gameController.bulletPrefab, transform.position + Vector3.down, Quaternion.identity);
			spawnedBullet.GetComponent<Bullet>().playerBullet = false;
			lastBulletSpawned = Time.time;
		}

	}

	public void SpawnPowerUp()
	{
		if(Random.Range(0, 100) < 1)
		{
			print("PowerUpSpawned");
			//Instantiate(GameController.gameController.powerUpPrefab, transform.position + Vector3.down, Quaternion.identity);
			//In here I would add code that would instantiate the powerUp prefab. See notes in GameController for details.
		}
	}
}
