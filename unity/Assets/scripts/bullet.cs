using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
 
	public float bulletSpeed;
	private float bulletSpawnTime;
	public AudioSource gunHit;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.forward * bulletSpeed * Time.deltaTime;

		}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Crate") 
		{
			gunHit.Play();
		}

		Destroy (transform.gameObject);


	}
}
