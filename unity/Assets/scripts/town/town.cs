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
			GameObject.FindWithTag("Player").transform.position = new Vector3(47,-0.5f,-84);
		}
		else if(Application.loadedLevelName == "lvl3")
		{
			GameObject.FindWithTag("Player").transform.position = new Vector3(1168,1,465);
		}
		else
		{
			Debug.Log("i hit an error finding Player, in town.cs");
		}
		if(!PlayerPrefs.HasKey("loot"))
		{
			PlayerPrefs.SetInt("loot",0);
		}
		if(!PlayerPrefs.HasKey("damage"))
		{
			if(PlayerPrefs.GetString("Char") == "Warrior")
			{
				PlayerPrefs.SetInt("damage",20);
			}
			else if(PlayerPrefs.GetString("Char") == "Gunman")
			{
				PlayerPrefs.SetInt("damage",10);
			}
			else if(PlayerPrefs.GetString("Char") == "Mage")
			{
				PlayerPrefs.SetInt("damage",50);
			}
		}
		if(!PlayerPrefs.HasKey("life"))
		{
			if(PlayerPrefs.GetString("Char") == "Warrior")
			{
				PlayerPrefs.SetInt("life",250);
			}
			else if(PlayerPrefs.GetString("Char") == "Gunman")
			{
				PlayerPrefs.SetInt("life",100);
			}
			else if(PlayerPrefs.GetString("Char") == "Mage")
			{
				PlayerPrefs.SetInt("life",150);
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
