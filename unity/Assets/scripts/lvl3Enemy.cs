using UnityEngine;
using System.Collections;

public class lvl3Enemy : MonoBehaviour {


	public int life = 35;
	private bool isAttacking;
	private bool isAlive = true;


	// Use this for initialization
	void Start () {
		//isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttacking == true) {
		
						this.animation.Play ("attack");
				
				} else {
			this.animation.Play("idle");		
		
		}
		if (life <= 0) {
				
			isAlive = false;
			this.animation.Play("die");
			Destroy(this.gameObject);
		
		}

	}

	public void damageTaken(int damage){


		life = life - damage;


	
	}

	void OnCollisionEnter(Collision collision){
		

		Debug.Log ("i've hit somethin'");

		if (collision.transform.tag == "weapon") {
			Debug.Log ("a sword hit me");
			int recieveDamage = collision.gameObject.GetComponent <sword>().getDamage();

				life = life - recieveDamage;

			this.animation.Play("gethit");


				//life = life - (collision.gameObject.GetComponent <sword>().getDamage);
			
			
			//collision.gameObject.GetComponent <sword>().getDamage();
			
		}
		
	}
}
