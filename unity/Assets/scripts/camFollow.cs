using UnityEngine;
using System.Collections;

public class camFollow : MonoBehaviour {

	public Transform Follower;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/*this.transform.position = Follower.position;
		Vector3 location = Follower.position;*/
	
		this.transform.position = new 
			Vector3(Follower.position.x-20.0f, Follower.position.y+40.0f, Follower.position.z);
	
		this.transform.LookAt(Follower);
	}

}