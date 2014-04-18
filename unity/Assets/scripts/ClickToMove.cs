using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour 
{
	public int life = 100;
	public int damage;

	public Transform mover;
	public float speed = 10;
	public float SnapTo = 0.5f; //how close we get before snapping to the desination
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
		newRotation *= Quaternion.Euler(0, -90, 0);
	
		newRotation.x = 0f;
		newRotation.z = 0f;

		this.transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime);
		
			//this.transform.rotation = (0, 90, 0);

			controllerMove.SimpleMove (transform.right * speed);
	
		}
	/*	if (Vector3.Distance(mover.position, position) < SnapTo) //are we within snap range?
			movePlayerToPosition.position = position; //snap to destination
		else 
			movePlayerToPosition.position = Vector3.MoveTowards(mover.transform.position, destination, Time.deltaTime * 10); //move toward destination
	}*/
	

}
}

	//void attack()
	//void collide()
	//bool dead()

