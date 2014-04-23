using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
 
	public float bulletSpeed = 5.0f;
	private float bulletSpawnTime;
	//public float destroyTime = 5.0f;

	// Use this for initialization
	void Start () {

		//bulletSpawnTime = Time.time + destroyTime;
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.forward * bulletSpeed * Time.deltaTime;

		/*if(bulletSpawnTime < Time.time)
		{
			Destroy (transform.gameObject);
		}
	
	*/}
	void OnCollisionEnter(Collision collision)
	{
		Destroy (transform.gameObject);
	}
}
