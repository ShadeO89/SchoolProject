using UnityEngine;
using System.Collections;

public class camFollow_claes : MonoBehaviour {


	private Transform Character;

	// Use this for initialization
	void Start () {
		Debug.Log(Application.loadedLevelName);

	}
	
	// Update is called once per frame
	void Update () {
		if(Character == null)
		{
			Character = GameObject.FindWithTag("Player").transform;
		}
		if(Application.loadedLevelName == "Town")
		{
		this.transform.position = Character.position + new Vector3(-10,40,0);
		this.transform.LookAt(Character);
		}
		else if(Application.loadedLevelName == "lvl1")
		{
			this.transform.position = Character.position + new Vector3(-30,30,0);
			this.transform.LookAt(Character);
		}
		else if(Application.loadedLevelName == "Level 2")
		{
			this.transform.position = Character.position + new Vector3(0,60,-20);
			this.transform.LookAt(Character);
		}
		else if(Application.loadedLevelName == "lvl3")
		{
			this.transform.position = Character.position + new Vector3(-20,40,0);
			this.transform.LookAt(Character);
		}
	}

	//interface
	void OnGUI()
	{
		//SCORE
		GUI.Box(new Rect(0,15,100,60), " ");
		GUI.Label(new Rect(0,0,100,50), "Player");
		GUI.Label(new Rect(0,15,100,50), "Gold:");
		GUI.Label(new Rect(0,30,100,50), PlayerPrefs.GetInt("loot").ToString());
		GUI.Label(new Rect(0,45,100,50), "Life:");
		GUI.Label(new Rect(0,60,100,50), PlayerPrefs.GetInt("life").ToString());
	}
}
