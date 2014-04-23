using UnityEngine;
using System.Collections;

public class camFollow_claes : MonoBehaviour {


	public Transform Character;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Character.position + new Vector3(-30,30,0);
	}
}
