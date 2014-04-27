using UnityEngine;
using System.Collections;

public class lvl3Enemy : MonoBehaviour {

	public int life = 35;
	public int damage = 10;
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
}
