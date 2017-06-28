using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject IntroPanel;
	public GameObject GameOverPanel;
	public EnemyContainer enemyContainer;
	public GameObject enemyPrefab;
	public GameObject playerPrefab;
	public GameObject bulletPrefab;
	public GameObject powerUpPrefab;
	public Vector2 enemyGridSize;
	public float enemySpeed;
	public float enemyStepSize;
	public int gameWidth = 20;
	public float playerSpeed = 1;
	public float bulletSpeed = 10;
	public float bulletSpwanSpeed = 2;

	public static GameController gameController;

	private void Awake()
	{
		gameController = this;
		GameOverPanel.SetActive(false);
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(BeginGame());
	}

	public void EnemyDestroyed(GameObject enemy)
	{
		enemyContainer.enemysInContainer--;
		enemyContainer.enemys.Remove(enemy);
		if (enemyContainer.enemysInContainer <= 0)
		{
			enemyContainer.SpawnNewGrid(enemyGridSize, enemyPrefab);
		}
	}

	public void GameOver()
	{
		GameOverPanel.SetActive(true);
	}

	public void Replay()
	{
		GameOverPanel.SetActive(false);
		IntroPanel.SetActive(true);
		StartCoroutine(BeginGame());
	}

	IEnumerator BeginGame()
	{
		yield return new WaitForSeconds(3);
		IntroPanel.SetActive(false);
		enemyContainer.SpawnNewGrid(enemyGridSize, enemyPrefab);
		Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
	}

	//Notes

	//I was planning to add power ups that would give the player faster movement speed, faster firing speed, etc when picked up.
	//The script would have had a similar trigger script as bullet added to it, then it would get the player componet and call a function within that would run a coroutine to last for a breif period that would upgrade one of the players abilities.
}
