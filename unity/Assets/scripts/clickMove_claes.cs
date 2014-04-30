using UnityEngine;
using System.Collections;

public class clickMove_claes : MonoBehaviour {

    // variables
	public int life;
	private Vector3 position;
	private Vector3 looking;
	public GameObject fireball;

	void Start () 
    {

	}
	

	void Update () 
    {
		get_animplaying(); //run get_animplaying function
	}



	void get_animplaying()
	{
		if(this.animation.IsPlaying("idle")) //if "idle" animation is playing
		{
			Debug.Log("idle");
			set_rotation(); //run set_rotation function
			set_position(); //run set_position function

		}
		else if(this.animation.IsPlaying("running")) // else if running anim is playing
		{
			Debug.Log("running");
			set_position(); //run set_position func.
			moveplayer(); //and moveplayer function
		}
		
        //checking for abillity to attack
		if(!this.animation.IsPlaying("attack")) //if attack anim is NOT playing
		{
			Debug.Log("can now attack");
			playerAttack();     //run playerAttack function
		}

	}
	
    //setting rotation
    void set_rotation()
	{
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //Creating a Ray variable called ray and setting it to be from Camera to mouseposition 
        RaycastHit hit; //Creating a RaycastHit variable called hit

        if (Physics.Raycast(ray, out hit)) // If the ray hits something (terrain/enemy whatever) save position in hit
		{
			looking = new Vector3(hit.point.x , hit.point.y , hit.point.z); //setting "looking" variable to this XYZ
            Quaternion rotation = Quaternion.LookRotation(looking - transform.position); //saving the rotation between 2 points
			rotation *= Quaternion.Euler (0, -90, 0); //Adjusting for blender error
			rotation.x = 0;//Dont rotate in x
			rotation.z = 0;//dont rotate in y
			this.transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime*5);//setting rotation speed
		
		}
	}
	void set_position() // set_position func.
	{
		if(Input.GetMouseButton(0)) //if mouse input == left mouse button
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //creating a ray going from camera to mouse position
			RaycastHit hit; //Creating a RaycastHit with the name hit
            if (Physics.Raycast(ray, out hit))  // if the ray hits something (terrain/enemy whatever)
			{
				position = new Vector3(hit.point.x , hit.point.y , hit.point.z); //position is set to this XYZ
				Debug.Log(position);
				this.animation.Play("running"); //and running anim is run
				Debug.Log("changed animation");
			}
		}
		else if (this.transform.position == position && !animation.IsPlaying("idle")) //else if character is standing still and idle anim is NOT run
		{
			animation.Play("idle"); //run idle anim
			Debug.Log("changed animation");
		}
	}
	void moveplayer() //moveplayer dunc
	{
        if (Vector3.Distance(this.transform.position, position) > 1) //if distance to the wanted position is larger than 1
		{

            Quaternion rotation = Quaternion.LookRotation(position - transform.position); //saving the rotation between 2 points
			rotation *= Quaternion.Euler (0, -90, 0); //adjusting to blender
			rotation.x = 0; //dont rotate x
			rotation.z = 0; //dont rotate z
			this.transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime*5); //set rotation speed
			this.rigidbody.velocity = transform.right * 10; //setting the speed of the rotation of the rigidbody

		}
		else
		{
			this.transform.position = position; //else stand still
		}
	}
	
    void playerAttack() //player attack function
	{
		if(Input.GetMouseButtonUp(1)) //if mouse input is right mouse button
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //set ray fro cam to mouse position
			RaycastHit hit; //creating RaycastHit variable hit
			if (Physics.Raycast(ray, out hit))  //if we hit anything
			{
				position = new Vector3(hit.point.x , hit.point.y , hit.point.z); //set position to this XYZ
				this.animation.Play("attack"); //run attack anim
				this.animation.PlayQueued("idle"); //run idle anim afterwards
				fireball.transform.position = this.transform.position + this.transform.right*3 + new Vector3(0,5,0); //Setting the position of where the fireball needs to go
				fireball.transform.rotation = Quaternion.LookRotation (position - transform.position); //Setting rotation of the fireball
				Instantiate(fireball); //instantiating the fireball
			}
		}
	}
}
