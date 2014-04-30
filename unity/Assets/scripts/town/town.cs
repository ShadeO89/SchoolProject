using UnityEngine;
using System.Collections;

public class town : MonoBehaviour {

	public GameObject gunman;
	public GameObject warrior;
	public GameObject mage;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetString("Char") == "Warrior")
		{
			Instantiate(warrior);
		}
		else if(PlayerPrefs.GetString("Char") == "Gunman")
		{
			Instantiate(gunman);
		}
		else if(PlayerPrefs.GetString("Char") == "Mage")
		{
			Instantiate(mage);
		}
		else
		{
			Debug.Log ("i hit an error, cannot load any characters");
			Application.Quit();
			//Instantiate(mage);
		}
		if(Application.loadedLevelName == "Town")
		{
			GameObject.FindWithTag("Player").transform.position = new Vector3(25,0,25);
		}
		else if(Application.loadedLevelName == "lvl1")
		{
			GameObject.FindWithTag("Player").transform.position = new Vector3(-200,3,300);
		}
		else if(Application.loadedLevelName == "Level 2")
		{
			GameObject.FindWithTag("Player").transform.position = new Vector3(47,-1,-84);
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
