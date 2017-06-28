using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	GameObject spawnedBullet;
	float lastBulletSpawned = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis("Horizontal") * GameController.gameController.playerSpeed * Time.deltaTime, 0, 0);

		if (Input.GetButtonDown("Jump") && Time.time - lastBulletSpawned >= 1 / GameController.gameController.bulletSpwanSpeed)
		{
			spawnedBullet = Instantiate(GameController.gameController.bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
			spawnedBullet.GetComponent<Bullet>().playerBullet = true;
			lastBulletSpawned = Time.time;
		}
	}
}
