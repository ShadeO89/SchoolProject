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
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
