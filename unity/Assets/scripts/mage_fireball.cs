using UnityEngine;
using System.Collections;

public class mage_fireball : MonoBehaviour {

	public GameObject boom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = transform.forward*10;
	}

	void OnCollisionEnter(Collision other)
	{
		Destroy(this.gameObject);
		boom.transform.position = this.transform.position;
		Instantiate(boom);
	}
}
