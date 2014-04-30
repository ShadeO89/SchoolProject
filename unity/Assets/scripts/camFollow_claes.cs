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
		else if(Application.loadedLevelName == "level2")
		{
			this.transform.position = Character.position + new Vector3(-30,30,0);
			this.transform.LookAt(Character);
		}
	}
}
