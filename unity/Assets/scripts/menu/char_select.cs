using UnityEngine;
using System.Collections;

public class char_select : MonoBehaviour {

	private GameObject choice;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0))
		{
			set_char();
			Application.LoadLevel(2);
		}
	
	}
	void set_char()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) 
		{
			if(hit.transform.name == "Terrain")
			{
				Debug.Log("i clicked on terrain");
			}
			else if(hit.transform.name == "Gunman_blurby")
			{
				Debug.Log("i clicked on gunman");
				PlayerPrefs.SetString("Char","Gunman");
			}
			else if(hit.transform.name == "Mage_blurby")
			{
				Debug.Log("i clicked on Mage");
				PlayerPrefs.SetString("Char","Mage");
			}
			else if(hit.transform.name == "warrior_blurby")
			{
				Debug.Log("i clicked on Warrior");
				PlayerPrefs.SetString("Char","Warrior");
			}
			else
			{
				Debug.Log("ive clicked on something");
				Debug.Log(hit.transform.name);
			}
			
		}
		Debug.Log(""+ PlayerPrefs.GetString("Char"));
	}
}
