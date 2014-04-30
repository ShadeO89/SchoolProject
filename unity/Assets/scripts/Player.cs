using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int life;
	//public TextMesh value;
	public AudioSource death;
	private int damage;

	// Use this for initialization
	void Start () {

		if(!PlayerPrefs.HasKey("life"))
		{life = 100; PlayerPrefs.SetInt("life",life);}
		else
		{life = PlayerPrefs.GetInt("life");}

		if(!PlayerPrefs.HasKey("damage"))
		{damage = 40;}
		else
		{damage = PlayerPrefs.GetInt("damage");}

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerPrefs.SetInt("life",life);
	}

	public void receiveDamage (int damage) {

		life -= damage;

	//	value.text = ""+life;

		if (life <= 0) {
			death.Play ();
			Destroy (this.gameObject);
			Application.LoadLevel(6);
		}
	}
	public int get_outputdamage()
	{
		return damage;
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Goal")
			Application.LoadLevel (2);

		if(Application.loadedLevelName == "Town")
		{
			goToLevel(collision);
		}

	}
	void goToLevel(Collision col)
	{
		if(col.transform.name == "lvl1")
		{
			Application.LoadLevel(3);
	
		}
		else if(col.transform.name == "lvl2")
		{
			Application.LoadLevel(4);
				
		}
		else if(col.transform.name == "lvl3")
		{
			Application.LoadLevel(5);
				
		}
		else
		{
			Debug.Log("i hit something else than gates");
		}
	}

}
