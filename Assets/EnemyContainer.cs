using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour {

	public List<GameObject> enemys = new List<GameObject>();

	bool containerMoving = false;
	bool movingRight = true;
	GameController gameController;

	Vector3 defaultPos;

	public int enemysInContainer = 0;
	float lastMoveTime;

	// Use this for initialization
	void Start() {
		defaultPos = transform.position;
		gameController = GameController.gameController;
	}

	// Update is called once per frame
	void Update() {
		if (containerMoving && Time.time - lastMoveTime >= 1 / gameController.enemySpeed)
		{
			transform.Translate(gameController.enemyStepSize * ( movingRight ? 1 : -1 ), 0, 0);

			if (Mathf.Abs(transform.position.x) == gameController.gameWidth / 2)
			{
				movingRight = !movingRight;
				transform.Translate(0, -1, 0);
			}

			lastMoveTime = Time.time;
		}
	}

	public void SpawnNewGrid(Vector2 gridSize, GameObject prefab)
	{
		foreach(GameObject obj in enemys)
		{
			Destroy(obj);
		}
		enemys.Clear();
		GameObject newEnemy;
		transform.position = defaultPos;
		for (int i = 0; i < gridSize.y; i++)
		{
			for (int j = (int)-gridSize.x / 2; j < gridSize.x / 2; j++)
			{
				newEnemy = Instantiate(prefab, new Vector3(j, i + transform.position.y, 0), Quaternion.identity, transform);
				enemysInContainer++;
				enemys.Add(newEnemy);
			}
		}
		containerMoving = true;
	}
}
