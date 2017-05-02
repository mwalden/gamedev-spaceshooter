using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public GameObject bulletPrefab;
	public float bulletSpeed;
	public float maxDistance;
	private GameObject bullet;
	private bool bulletFired;


	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !bulletFired) {
			bulletFired = true;	
			bullet = Instantiate (bulletPrefab, transform.position, Quaternion.identity) as GameObject;
		}
		if (bulletFired) {
			Vector3 position = bullet.transform.position;
			bullet.transform.position = new Vector3 (position.x + bulletSpeed * Time.deltaTime,
				position.y, position.z);
			if (position.x >= maxDistance) {
				bulletFired = false;
				Destroy (bullet);
			}
		}
	}

	public void destroyBullet(GameObject bullet){
		bulletFired = false;
		Destroy (bullet);
	}




}
