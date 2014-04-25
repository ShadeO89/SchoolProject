using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {

	public int loot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			loot += 10;

			Destroy (transform.gameObject);
		}


	}
}
