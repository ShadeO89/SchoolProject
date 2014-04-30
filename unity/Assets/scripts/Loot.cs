using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {
	
	private int loot;
	private GameObject cam;

	// Use this for initialization
	void Start () {
		loot = PlayerPrefs.GetInt("loot");
	
	}
	
	// Update is called once per frame
	void Update () {
		loot = PlayerPrefs.GetInt("loot");

	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") 
		{

			loot = PlayerPrefs.GetInt("loot") +50; 
			PlayerPrefs.SetInt("loot",loot);
			Debug.Log (PlayerPrefs.GetInt("loot"));


			Destroy (this.transform.gameObject);
		}


	}

}
