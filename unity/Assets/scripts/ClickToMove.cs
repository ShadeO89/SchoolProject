using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour 
{
	public int life = 100;
	public float speed = 2.0f;
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
		if (Input.GetMouseButtonDown(0)) {
			locatePosition();		
		//Locate where the Player clicked terrain

		}
	// move player to position
	
		movePlayerToPosition ();

		if (this.transform.position == position && !animation.IsPlaying("attack_swipe") && !animation.IsPlaying("attack_stab")) 
		{
				this.animation.Play ("idle");
		} 
		else if (!animation.IsPlaying("attack_swipe") && !animation.IsPlaying("attack_stab"))
		{
			this.animation.Play ("running");
		
		}
	
	}

	void locatePosition()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) 
		{
			if (hit.transform.tag == "Enemy") 
			{ 
				attack (hit.point);
			}
			else
			{
			position = new Vector3(hit.point.x , hit.point.y , hit.point.z);
			}
		}

	}


	void movePlayerToPosition(){
				if (Vector3.Distance (this.transform.position, position) > 1) {
						Quaternion newRotation = Quaternion.LookRotation (position - transform.position);

						newRotation *= Quaternion.Euler (0, -90, 0);

	
						newRotation.x = 0f;
						newRotation.z = 0f;

						this.transform.rotation = Quaternion.Lerp (transform.rotation, newRotation, Time.deltaTime*10);

						controllerMove.SimpleMove (transform.right * speed);
	
				}
				if (Vector3.Distance (this.transform.position, position) < SnapTo) //are we within snap range?
						this.transform.position = position; //snap to destination

			}



	void attack(Vector3 hit)
	
	{

		if(Vector3.Distance(this.transform.position, hit)<10) 
		{

		this.animation.Play("attack_swipe");
		this.animation.PlayQueued("idle");
		}
}


	//void attack()
	//void collide()
	//bool dead()

}