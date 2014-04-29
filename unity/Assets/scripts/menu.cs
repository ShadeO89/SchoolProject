using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	
	
	private delegate void StartMenu();
	private StartMenu menuFunction;
	
	private float screenHeight;
	private float screenWidth;
	private float buttonHeigth;
	private float buttonWidth;
	
	// Use this for initialization
	void Start () {
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
		buttonHeigth = screenHeight * 0.1f;
		buttonWidth = screenWidth * 0.2f;
		
		menuFunction = mainMenu;
		
	}
	
	void OnGUI() {
		GUI.Label(new Rect(Screen.width / 2 - 100, -30, 200, 100), "TWO GIRLS, ONE CODE");
		menuFunction();
	}
	void anyKey() {
		if(Input.anyKey){
			menuFunction = mainMenu;
			
		}
		
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(screenWidth * 0.45f, screenHeight  * 0.45f, screenWidth * 0.1f, screenHeight * 0.1f), "press any key ");
	}
	
	void mainMenu(){
		if (GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.2f, buttonWidth, buttonHeigth), "Start game")){
			Application.LoadLevel(1);
			PlayerPrefs.SetInt("rosaScore", 0);
			PlayerPrefs.SetInt("violaScore", 0);
			//Start game
		}
		if (GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.4f, buttonWidth, buttonHeigth), "Highscore"))
		{
			Application.LoadLevel(2);
			//Loads Highscore
		}
		if (GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.6f, buttonWidth, buttonHeigth), "TROLL BUTTON"))
		{
			Application.Quit();
			// Quit game
		}
	}
}