using UnityEngine;
using System.Collections;

public class upgrade : MonoBehaviour {

	private int damage;
	private int life;
	private int loot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//checks for key press to upgrade
		loot = PlayerPrefs.GetInt("loot");
		if(loot > 50)
		{
			if(Input.GetKeyUp(KeyCode.H))
			{
				life = PlayerPrefs.GetInt("life");
				life += 20;
				loot -= 50;
				PlayerPrefs.SetInt("loot",loot);
				PlayerPrefs.SetInt("life",life);
			}
			else if(Input.GetKeyUp(KeyCode.D))
			   {
				damage = PlayerPrefs.GetInt("damage");
				damage += 10;
				loot -= 50;
				PlayerPrefs.SetInt("loot",loot);
				PlayerPrefs.SetInt("damage",damage);
			}
		}

	}
}
