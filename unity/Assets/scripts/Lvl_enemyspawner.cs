using UnityEngine;
using System.Collections;

public class Lvl_enemyspawner : MonoBehaviour {
	public float timer;
	public float spawntime;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
		spawntime = 5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += 1*Time.deltaTime;
		if(spawntime<timer)
		{
			timer = 0.0f;
			spawn();
		}
	}
	void spawn()
	{
		Vector3 position = new Vector3(Random.Range(-500,500),0,Random.Range(-500,500));
		Instantiate(enemy, position, Quaternion.identity);
		Debug.Log ("Spawner made new skeleton");

	}
}
