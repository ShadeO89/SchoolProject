using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour {

	public int damage = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnCollisionEnter(Collision collision){
		
		
		if (collision.transform.tag == "Enemy") {
			
			
			collision.gameObject.GetComponent <lvl3Enemy>().damageTaken(damage);
			
			
			
		}
		
	}*/

	public int getDamage() 
	{ return damage; }
	
}
