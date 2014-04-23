using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
 
	public float bulletSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.forward * bulletSpeed * Time.deltaTime;

	
	}
}
