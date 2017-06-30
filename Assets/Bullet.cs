using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public bool playerBullet = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate((playerBullet ? Vector3.up : Vector3.down) * Time.deltaTime * GameController.gameController.bulletSpeed);

		if (transform.position.y > 30 || transform.position.y < -10)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Enemy(Clone)" && playerBullet)
		{
			col.GetComponent<Enemy>().SpawnPowerUp();
			GameController.gameController.EnemyDestroyed(col.gameObject);
			Destroy(col.gameObject);
			Destroy(this.gameObject);
		}
		else if(col.name == "Player(Clone)" && !playerBullet)
		{
			GameController.gameController.GameOver();
			Destroy(col.gameObject);
			Destroy(this.gameObject);
		}
	}
}
