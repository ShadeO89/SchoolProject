using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public AudioSource Boom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "TNT") 
		{
			Boom.Play();
			Destroy (transform.gameObject);
		}


	}
}
