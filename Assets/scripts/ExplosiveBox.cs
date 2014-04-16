using UnityEngine;
using System.Collections;

public class ExplosiveBox : MonoBehaviour {

	public Transform Explosion;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
 
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "FireBall"){

		GameObject exp = Instantiate(Explosion, rigidbody.position, Quaternion.identity) as GameObject;
		Destroy(exp,5);
		other.transform.position = transform.position;
		Destroy(gameObject);
		other.transform.localScale = new Vector3(5,2,5);
		Destroy(other.gameObject,0.1f);
		}
	}

}
