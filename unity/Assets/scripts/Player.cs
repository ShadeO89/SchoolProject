using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int life = 100;
	//public TextMesh value;
	public AudioSource death;
	private int damage = 20;

	// Use this for initialization
	void Start () {

	//	value.text = ""+life;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void receiveDamage (int damage) {

		life -= damage;

	//	value.text = ""+life;

		if (life <= 0) {
			death.Play ();
			Destroy (this.gameObject);
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	public int get_outputdamage()
	{
		return damage;
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Goal")
			Application.LoadLevel (Application.loadedLevel);
	}

}
