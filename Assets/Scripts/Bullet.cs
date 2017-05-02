using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	EnemyController enemyController;
	BulletController bulletController;

	void Start(){
		enemyController = FindObjectOfType<EnemyController> ();
		bulletController = FindObjectOfType <BulletController> ();
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag.Equals("Player"))
			return;
		enemyController.destroyEnemy (coll.gameObject);
		bulletController.destroyBullet (gameObject);
	}
}
