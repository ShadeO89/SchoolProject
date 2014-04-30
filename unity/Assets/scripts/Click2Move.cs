using UnityEngine;
using System.Collections;

public class Click2Move : MonoBehaviour 
{
	
    public Transform mover; //the object being moved
	public float SnapTo = 0.5f; //how close we get before snapping to the desination
    private Vector3 destination = Vector3.zero; //where we want to move
	//bullet stuff
	public GameObject leftBulletSpawn;
	public GameObject rightBulletSpawn;
	public Transform bullet;
	private bool leftSpawner = true;
	//sounds
	public AudioSource gunShot;
	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip attack;


	// Use this for initialization
	void Start ()
    {
        destination = mover.position; //set the destination to the objects position when the script is run the first time
		  
		
	}
	
	// Update is called once per frame
    void Update()
    {
		
		//finding the point of the cursor 
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    	RaycastHit hit;
    	Physics.Raycast(ray, out hit);
		//makes character look at mouse
		Vector3 newRotation = Quaternion.LookRotation(hit.point - mover.position).eulerAngles;
		newRotation.x = 0;
		newRotation.z = 0;
		newRotation.y = newRotation.y - 90;
		mover.rotation = Quaternion.Euler(newRotation);
        
		// when left mouse button is pressed - movement
        if (Input.GetMouseButtonDown(0))
        {
           
            if (Physics.Raycast(ray, out hit)) //did we hit something?
			if(hit.transform.name != "Crate")//if (hit.transform.name == "Plane" | hit.transform.tag == "Loot" | hit.transform.tag == "trigger") //did we hit the ground?
                    destination = hit.point; //set the destinatin to the vector3 where the ground was contacted
        }
		// shooting and changing R/L gun
		if (Input.GetMouseButtonDown (1)) 
		{
			//sounds and animation played
			gunShot.Play();
			animation.Play(attack.name);



			if (leftSpawner) 
			{
				Instantiate (bullet, leftBulletSpawn.transform.position, leftBulletSpawn.transform.rotation * Quaternion.Euler(0,90,0));
			} else {
				Instantiate (bullet, rightBulletSpawn.transform.position, rightBulletSpawn.transform.rotation * Quaternion.Euler(0,90,0));
			} 
			leftSpawner = !leftSpawner; 
		}

        // move the object toward the destination
		if (Vector3.Distance (mover.position, destination) < SnapTo) { //are we within snap range?
			mover.position = destination; //snap to destination
			animation.CrossFade (idle.name);
		}else{
			mover.position = Vector3.MoveTowards (mover.transform.position, destination, Time.deltaTime * 10); //move toward destination
			animation.CrossFade (run.name);
		}
	}
}