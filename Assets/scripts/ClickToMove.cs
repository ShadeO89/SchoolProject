using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour 
{
	//int life;
	//int damage;

	public float speed = 10;
	private Vector3 position;
	public CharacterController controllerMove;

	// Use this for initialization
	void Start () 	
	{
		position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0)) {
			locatePosition();		
		//Locate where the Player clicked terrain

		}
	// move player to position
	
		movePlayerToPosition ();
	
	}

	void locatePosition()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) 
		{
			position = new Vector3(hit.point.x , hit.point.y , hit.point.z);
			Debug.Log(position);
		}

	}
	void movePlayerToPosition(){
	if(Vector3.Distance(this.transform.position , position) >1){
		Quaternion newRotation = Quaternion.LookRotation(position-transform.position);
	
		newRotation.x = 0f;
		newRotation.z = 0f;

		this.transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime);
		controllerMove.SimpleMove (transform.forward * speed);
	
		}

	}

	//void attack()
	//void collide()
	//bool dead()
}
