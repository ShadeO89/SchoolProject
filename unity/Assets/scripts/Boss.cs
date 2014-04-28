using UnityEngine;
using System.Collections;




public class Boss : MonoBehaviour {

	public float speed;
	public float range;
	public float bulletPower = 10.0f;
	public float health = 100;
	public int damage = 10;
	public Transform Explosion;
	public Transform gate;

	public CharacterController controller;

	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip die;
	public AnimationClip attack;

	private Transform player;

	private float attackAnimWaitTime = 0;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Gunman").transform;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!animation.IsPlaying(die.name)) {

			if (!inRange ()) {
				chase ();
				attackAnimWaitTime = 0;
			} else {
				if (attackAnimWaitTime <= 0) {
					animation.CrossFade (attack.name);
					player.gameObject.GetComponent<Player> ().receiveDamage (damage);
					attackAnimWaitTime = attack.length;
				} else {
					attackAnimWaitTime -= Time.deltaTime;
				}
			}
		}
	}

	bool inRange(){
		if (Vector3.Distance (transform.position, player.position) < range) {
			return true;
		} else {
			return false;
		}
	}

	void chase()
	{
		transform.LookAt(player.position);
		controller.SimpleMove(transform.forward*speed);
		animation.CrossFade(run.name);
	}

	void OnMouseOver()
	{
		//player.GetComponent<Gunner>().opponent = gameObject;
	}
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "bullet")
			health = health - bulletPower;
		if(health <= 0)
		{

			animation.CrossFade(die.name);

			CharacterController cc = (CharacterController) this.gameObject.GetComponent ("CharacterController");
			cc.enabled = false;

			Invoke ("DestroySkeleton", die.length);
		}
	}

	void DestroySkeleton()
	{
		Destroy (this.gameObject);

	}
}
