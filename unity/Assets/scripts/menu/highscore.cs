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


		firstplace = PlayerPrefs.GetInt("firstplace");
		secondplace = PlayerPrefs.GetInt("secondplace");
		thirdplace = PlayerPrefs.GetInt("thirdplace");
		
		GetScore();
		checkScore();
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
		buttonHeigth = screenHeight * 0.1f;
		buttonWidth = screenWidth * 0.2f;

		PlayerPrefs.SetInt("firstplace",firstplace);
		PlayerPrefs.SetInt("secondplace",secondplace);
		PlayerPrefs.SetInt("thirdplace",thirdplace);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() 
	{



			GUI.Label(new Rect (515, 10 * 1, 300, 500), "1.  " + firstplace); 
			GUI.Label(new Rect (515, 10 * 2, 300, 500), "2.  " + secondplace); 
			GUI.Label(new Rect (515, 10 * 3, 300, 500), "3.  " + thirdplace); 

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

		{
			thirdplace = score;
		}
	}


}
