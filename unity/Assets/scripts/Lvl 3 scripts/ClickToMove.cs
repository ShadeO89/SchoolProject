using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour 
{
    //Variables
	public int life = 100;
	public float speed = 2.0f;
	public float SnapTo = 0.5f; //how close we get before snapping to the desination
	private Vector3 position;
	public CharacterController controllerMove;

	// Use this for initialization
	void Start () 	
	{
		//Instantiating start position
        position = this.transform.position;
	}
	


	// Update is called once per frame
	void Update ()
        {   //Locate where the Player clicked terrain
		if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) {
			locatePosition();		
		}
	
        // Move player to position
		movePlayerToPosition ();

		if (this.transform.position == position && !animation.IsPlaying("attack_swipe") && !animation.IsPlaying("attack_stab")) //if the player is not trying to move and attack animations are not running 
		    {
			this.animation.Play ("idle"); //run idle animation
		    }

        else if (!animation.IsPlaying("attack_swipe") && !animation.IsPlaying("attack_stab")) // if the attack animations are not running
		    {
			this.animation.Play ("running"); //run running animation
		    }
	}

	void locatePosition()
	{
		RaycastHit hit; //Creating a RaycastHit variable called hit
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Creating a Ray variable called ray and setting it to be from Camera to mouseposition 
		
        if (Physics.Raycast(ray, out hit)) // If the ray hits something (terrain/enemy whatever) save position in hit
		{
			if (hit.transform.tag == "Enemy") // If we are hitting an object that is tagged "Enemy" 
			    { 
				attack (hit.point); //run attack function
			    }
			
            else
			        {
			        position = new Vector3(hit.point.x , hit.point.y , hit.point.z); //Else position variable is set to this XYZ
			        }
		}

	}

	void movePlayerToPosition() //Moving player to the position located earlier
    {
				if (Vector3.Distance (this.transform.position, position) > 1)  //If the distance to the wanted position is larger than 1
                {
						
						Quaternion newRotation = Quaternion.LookRotation (position - transform.position); //saving the rotation between 2 points

						newRotation *= Quaternion.Euler (0, -90, 0); //adjusting the rotation because our blender model was not centered

						newRotation.x = 0f; //Not turning on the X-axis
                        newRotation.z = 0f;//Not turning on the Z-axis

						this.transform.rotation = Quaternion.Lerp (transform.rotation, newRotation, Time.deltaTime*10); //setting the speed of the rotation and using Lerp as Slerp meant that the Character wouldn't turn the way we wanted

						controllerMove.SimpleMove (transform.right * speed);
				}
                         //are we within snap range?
                         if (Vector3.Distance (this.transform.position, position) < SnapTo)
                         { 
				            this.transform.position = position; //snap to destination
                         }
	}

	//Attack function taking Hit as input
    void attack(Vector3 hit)
	{
		if(Vector3.Distance(this.transform.position, hit)<10) //If the range between enemy adn player is less than 10
		{
			Quaternion rotation = Quaternion.LookRotation (hit - transform.position);
			rotation *= Quaternion.Euler (0, -90, 0);
			rotation.x = 0;
			rotation.z = 0;
			this.transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime*5); //rotate towards enemy in the y axis
			
			if(Input.GetMouseButton(1)) //if the right mousebutton is pressed
			{	
				this.animation.Play ("attack_stab"); //run stab animation
				this.animation.PlayQueued("idle");//run idle directly afterwards
			}
			
            else    {
					this.animation.Play("attack_swipe"); //else run swipe anim.
					this.animation.PlayQueued("idle");//idle afterwards
				    }
		}
	}
}