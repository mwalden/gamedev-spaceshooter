using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

	public GameObject enemyPrefab_pandora;
	public GameObject enemyPrefab_spotify;
	public ScoreScript scoreScript;
	public float enemySpeed;
	public float secondsBetweenEnemySpawn;
	public int enemiesInGroup;
	public float distanceBetween;
	private bool spawned;
	private List<GameObject> enemies;
	private float time;
	private bool stopSpawningEnemies;

	private bool useBlueEnemy;

	void Start(){
		enemies = new List<GameObject> ();
		time = secondsBetweenEnemySpawn;
	}

	void Update () {
		time -= Time.deltaTime;
		if (time <= 0 && !spawned)
			spawnEnemy();
		if (spawned)
			moveEnemies ();
		if (spawned && enemies.Count == 0) {
			spawned = false;
			time = secondsBetweenEnemySpawn; 
		}
	}

	void spawnEnemy(){
		if (stopSpawningEnemies)
			return;
		spawned = true;
		enemies = new List<GameObject> ();
		float xPosition = transform.position.x;
		float yPosition = Random.Range (-3, 3);
		GameObject enemyToUse = useBlueEnemy ? enemyPrefab_pandora : enemyPrefab_spotify;
		for (int i = 0; i < enemiesInGroup; i++) {
			xPosition += distanceBetween;
			GameObject enemyShip = Instantiate(enemyToUse,new Vector3(xPosition, yPosition,0),Quaternion.identity) as GameObject;
			enemies.Add (enemyShip);
		}
		useBlueEnemy = !useBlueEnemy;
		spawned = true;

	}

	public void setStopSpawningEnemies(){
		stopSpawningEnemies = true;
	}

	public void destroyEnemy(GameObject enemy){
		scoreScript.addScore ();
		enemies.Remove (enemy);
		Destroy (enemy);
	}

	void moveEnemies(){
		List<GameObject> enemiesToDestroy = new List<GameObject> ();
		foreach (GameObject enemy in enemies) {
			if (enemy.transform.position.x <= -10) {
				enemiesToDestroy.Add (enemy);
			} else {
				if (useBlueEnemy) {
					enemy.transform.position = new Vector3 (enemy.transform.position.x - enemySpeed * Time.deltaTime,
						enemy.transform.position.y, enemy.transform.position.z);
				} else {
					float xPosition = enemy.transform.position.x - enemySpeed * Time.deltaTime;
					float yPosition = 2 * Mathf.Sin (xPosition);
					enemy.transform.position = new Vector3 (xPosition, yPosition, 0);
				}
			}
		}
		foreach (GameObject enemy in enemiesToDestroy) {
			enemies.Remove (enemy);
			Destroy (enemy);
		}
	}


}
