using UnityEngine;
using System.Collections;




public class Mob : MonoBehaviour {

	public float speed;
	public float range;
	public float bulletPower = 10.0f;
	public float health = 35;

	public CharacterController controller;

	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip die;
	public AnimationClip attack;

	private Transform player;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Gunman").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!inRange())
		{
		chase ();
		}else{
			animation.CrossFade(attack.name);
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
		player.GetComponent<Gunner>().opponent = gameObject;
	}
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "bullet")
			health = health - bulletPower;
		if(health <= 0)
		{
			animation.CrossFade(die.name);
			Destroy (this.gameObject);
		}
	}
}
