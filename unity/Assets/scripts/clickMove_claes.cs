using UnityEngine;
using System.Collections;

public class clickMove_claes : MonoBehaviour {

	public int life;
	private Vector3 position;
	private Vector3 looking;
	public GameObject fireball;

	void Start () {
		//forcing him to start at target position
		this.transform.position = new Vector3(-200,3,300);


	}
	

	void Update () {
		get_animplaying();
	}

	void get_animplaying()
	{
		if(this.animation.IsPlaying("idle"))
		{
			Debug.Log("idle");
			set_rotation();
			set_position();

		}
		else if(this.animation.IsPlaying("running"))
		{
			Debug.Log("running");
			set_position();
			moveplayer();
		}
		//checking for abillity to attack
		if(!this.animation.IsPlaying("attack"))
		{
			Debug.Log("can now attack");
			playerAttack();
		}

	}
	void set_rotation()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) 
		{
			looking = new Vector3(hit.point.x , hit.point.y , hit.point.z);
			Quaternion rotation = Quaternion.LookRotation (looking - transform.position);
			rotation *= Quaternion.Euler (0, -90, 0);
			rotation.x = 0;
			rotation.z = 0;
			this.transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime*5);
		
		}
	}
	void set_position()
	{
		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) 
			{
				position = new Vector3(hit.point.x , hit.point.y , hit.point.z);
				Debug.Log(position);
				this.animation.Play("running");
				Debug.Log("changed animation");
			}
		}
		else if (this.transform.position == position && !animation.IsPlaying("idle"))
		{
			animation.Play("idle");
			Debug.Log("changed animation");
		}
	}
	void moveplayer()
	{
		if (Vector3.Distance (this.transform.position, position) > 1) 
		{

			Quaternion rotation = Quaternion.LookRotation (position - transform.position);
			rotation *= Quaternion.Euler (0, -90, 0);
			rotation.x = 0;
			rotation.z = 0;
			this.transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime*5);
			this.rigidbody.velocity = transform.right * 10;

		}
		else
		{
			this.transform.position = position;
		}
	}
	void playerAttack()
	{
		if(Input.GetMouseButtonUp(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) 
			{
				position = new Vector3(hit.point.x , hit.point.y , hit.point.z);
				this.animation.Play("attack");
				this.animation.PlayQueued("idle");
				fireball.transform.position = this.transform.position + this.transform.right*3 + new Vector3(0,5,0);
				fireball.transform.rotation = Quaternion.LookRotation (position - transform.position);
				Instantiate(fireball);
			}
		}
	}
}
