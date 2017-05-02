using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float maxY = 4;
	public float minY = -4;
	public float speed = 10;
	public Animator fire;

	public EnemyController enemyController;
	private float secondsToBlowup = 2;

	private bool dead;
	// Update is called once per frame
	void Update () {
		if (dead) {
			transform.position = new Vector3(transform.position.x,
				transform.position.y - 3 * Time.deltaTime,
				0);
//			secondsToBlowup -= Time.deltaTime;
			if (transform.position.y <= minY - 2)
				Destroy (this.gameObject);
			return;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (transform.position.y <= maxY) {
				transform.position = new Vector3(transform.position.x,
					transform.position.y + speed * Time.deltaTime,
					0);
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			if (transform.position.y >= minY) {
				transform.position = new Vector3(transform.position.x,
					transform.position.y - speed * Time.deltaTime,
					0);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag.Equals("bullet"))
			return;
			

		Debug.Log ("!!!");
		fire.gameObject.SetActive (true);
		dead = true;
		enemyController.destroyEnemy (coll.gameObject);
		enemyController.setStopSpawningEnemies ();

	}
}
