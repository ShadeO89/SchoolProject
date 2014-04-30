using UnityEngine;
using System.Collections;

public class highscore : MonoBehaviour {

	public int firstplace;
	public int secondplace;
	public int thirdplace;
	private int score;
	private float screenHeight;
	private float screenWidth;
	private float buttonHeigth;
	private float buttonWidth;

	// Use this for initialization
	void Start () {

<<<<<<< HEAD
<<<<<<< HEAD
=======
		firstplace = PlayerPrefs.GetInt("firstplace");
		secondplace = PlayerPrefs.GetInt("secondplace");
		thirdplace = PlayerPrefs.GetInt("thirdplace");
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8
=======
		firstplace = PlayerPrefs.GetInt("firstplace");
		secondplace = PlayerPrefs.GetInt("secondplace");
		thirdplace = PlayerPrefs.GetInt("thirdplace");
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8
		GetScore();
		checkScore();
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
		buttonHeigth = screenHeight * 0.1f;
		buttonWidth = screenWidth * 0.2f;
<<<<<<< HEAD
<<<<<<< HEAD
=======
		PlayerPrefs.SetInt("firstplace",firstplace);
		PlayerPrefs.SetInt("secondplace",secondplace);
		PlayerPrefs.SetInt("thirdplace",thirdplace);
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8
=======
		PlayerPrefs.SetInt("firstplace",firstplace);
		PlayerPrefs.SetInt("secondplace",secondplace);
		PlayerPrefs.SetInt("thirdplace",thirdplace);
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() 
	{


<<<<<<< HEAD
<<<<<<< HEAD
			GUI.Label(new Rect (515, 10 * 1, 300, 500), "1.  " + firstplace); 
			GUI.Label(new Rect (515, 10 * 2, 300, 500), "2.  " + secondplace); 
			GUI.Label(new Rect (515, 10 * 3, 300, 500), "3.  " + thirdplace); 
=======
		GUI.Label(new Rect (515, 10 * 1, 300, 500), "1.  " + firstplace); 
		GUI.Label(new Rect (515, 10 * 2, 300, 500), "2.  " + secondplace); 
		GUI.Label(new Rect (515, 10 * 3, 300, 500), "3.  " + thirdplace); 
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8
=======
		GUI.Label(new Rect (515, 10 * 1, 300, 500), "1.  " + firstplace); 
		GUI.Label(new Rect (515, 10 * 2, 300, 500), "2.  " + secondplace); 
		GUI.Label(new Rect (515, 10 * 3, 300, 500), "3.  " + thirdplace); 
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8

		if (GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.2f, buttonWidth, buttonHeigth), "Return to menu")){
			Application.LoadLevel(0);
			//Returns to menu
		}
	}
	void GetScore()
	{
		score = PlayerPrefs.GetInt("loot");
	}
	void checkScore()
	{
		if(score > firstplace)
		{
<<<<<<< HEAD
<<<<<<< HEAD
			thirdplace = secondplace; secondplace = firstplace; firstplace = score;
		}
		else if(score > secondplace)
		{
			thirdplace = secondplace; secondplace = score; 
		}
		if(score > thirdplace)
=======
=======
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8
			thirdplace = secondplace; 
			secondplace = firstplace; 
			firstplace = score;
		}
		else if(score > secondplace)
		{
			thirdplace = secondplace; 
			secondplace = score; 
		}
		else if(score > thirdplace)
<<<<<<< HEAD
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8
=======
>>>>>>> 06d7c9adcd8814c0e5e1c2ea0be3aa142209e0f8
		{
			thirdplace = score;
		}
	}


}
