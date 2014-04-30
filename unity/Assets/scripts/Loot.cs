using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {

	public TextMesh value;
	private int loot;

	// Use this for initialization
	void Start () {
		loot = PlayerPrefs.GetInt("loot");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") 
		{

			loot = PlayerPrefs.GetInt("loot") +50; 
			PlayerPrefs.SetInt("loot",loot);
			value.text = loot.ToString();
			Debug.Log (PlayerPrefs.GetInt("loot"));


			Destroy (this.transform.gameObject);
		}


	}
}
