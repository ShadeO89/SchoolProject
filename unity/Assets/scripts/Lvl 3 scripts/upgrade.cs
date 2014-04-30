using UnityEngine;
using System.Collections;

public class upgrade : MonoBehaviour {

	private int damage;
	private int life;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.H))
		{
			life = PlayerPrefs.GetInt("life");
			life += 20;
			PlayerPrefs.SetInt("life",life);
		}
		else if(Input.GetKeyUp(KeyCode.D))
		   {
			damage = PlayerPrefs.GetInt("damage");
			damage += 10;
			PlayerPrefs.SetInt("damage",damage);
		}

	}
}
