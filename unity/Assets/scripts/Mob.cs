using UnityEngine;
using System.Collections;




public class Mob : MonoBehaviour {

	public float speed;
	public float range;
	public float health = 35;
	public int damage = 2;
	public Transform Explosion;
	public AudioSource swordHit;

	public CharacterController controller;
	
	public AnimationClip die;
	public AnimationClip attack;

	private Transform player;

	private float attackAnimWaitTime = 0;


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
		if (!animation.IsPlaying("die")) {

			if (!inRange() ) 
			{
				chase ();
				attackAnimWaitTime = 0;
			} 
			else 
			{
				if (attackAnimWaitTime <= 0) 
				{
					animation.CrossFade (attack.name);
					player.gameObject.GetComponent<Player> ().receiveDamage (damage);
					attackAnimWaitTime = attack.length;
				} 
				else 
				{
					attackAnimWaitTime -= Time.deltaTime;
				}
			}
		}
	}
	
	bool inRange()
	{
		if (Vector3.Distance (transform.position, player.position) < range) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}

	void chase()
	{
		transform.LookAt(player.position);
		controller.SimpleMove(transform.forward*speed);
		animation.CrossFade("run");
	}


	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "weapon")
		{
			health = health - player.gameObject.GetComponent<Player> ().get_outputdamage();
		}
		if (collision.transform.tag == "Player") {
			Debug.Log ("a sword hit me");
			Debug.Log(collision.gameObject.animation.IsPlaying("attack_swipe"));
			
			if(collision.gameObject.animation.IsPlaying("attack_swipe") || collision.gameObject.animation.IsPlaying("attack_stab"))
				
			{
				swordHit.Play();

				health = health - player.gameObject.GetComponent<Player> ().get_outputdamage();
				Debug.Log (health);
				this.animation.Play("gethit");
				this.animation.PlayQueued("idle");
				
				
			}
			
		}


		if(health <= 0)
		{

			animation.CrossFade("die");

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
