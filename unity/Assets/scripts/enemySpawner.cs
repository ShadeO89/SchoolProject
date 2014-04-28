using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public GameObject spawner1;
	public GameObject spawner2;
	public GameObject spawner3;
	public GameObject spawner4;
	public Transform enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {


		if (collision.gameObject.tag == "Player") {
			Instantiate (enemy, spawner1.transform.position, spawner1.transform.rotation);
			Instantiate (enemy, spawner2.transform.position, spawner2.transform.rotation);
			Instantiate (enemy, spawner3.transform.position, spawner3.transform.rotation);
			Instantiate (enemy, spawner4.transform.position, spawner4.transform.rotation);
		}
	}
}
