using UnityEngine;
using System.Collections;

public class lvl3Enemy : MonoBehaviour {


	public int life = 35;
	private bool isAttacking;
	private bool isAlive = true;
	public AudioSource swordHit;


	// Use this for initialization
	void Start () {
		//isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttacking == true) {
		
						this.animation.Play ("attack");
				
		} else if (!this.animation.IsPlaying("gethit")){
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
		

	//	Debug.Log ("i've hit somethin'");

		if (collision.transform.tag == "Player") {
			Debug.Log ("a sword hit me");

			if(collision.gameObject.animation.IsPlaying("attack_swipe") || collision.gameObject.animation.IsPlaying("attack_stab"))
			
			{
				swordHit.Play();
				
				life = life - 20;

				this.animation.Play("gethit");
				this.animation.PlayQueued("idle");


			}
//			int recieveDamage = gameObject.GetComponent <sword>().getDamage();



				//life = life - (collision.gameObject.GetComponent <sword>().getDamage);
			
			
			//collision.gameObject.GetComponent <sword>().getDamage();
			
		}
		
	}
}
