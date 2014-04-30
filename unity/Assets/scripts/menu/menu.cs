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
		//sets scrren size into variables
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		//sets size of buttons
		buttonHeigth = screenHeight * 0.1f;
		buttonWidth = screenWidth * 0.2f;
		
		menuFunction = mainMenu;
		//resets damage loot and life if they exist already
		if(PlayerPrefs.HasKey("loot"))
		{
			PlayerPrefs.SetInt("loot",0);
		}
		if(PlayerPrefs.HasKey("damage"))
		{
			if(PlayerPrefs.GetString("Char") == "Warrior")
			{
				PlayerPrefs.SetInt("damage",20);
			}
			else if(PlayerPrefs.GetString("Char") == "Gunman")
			{
				PlayerPrefs.SetInt("damage",10);
			}
			else if(PlayerPrefs.GetString("Char") == "Mage")
			{
				PlayerPrefs.SetInt("damage",50);
			}
		}
		if(PlayerPrefs.HasKey("life"))
		{
			if(PlayerPrefs.GetString("Char") == "Warrior")
			{
				PlayerPrefs.SetInt("life",250);
			}
			else if(PlayerPrefs.GetString("Char") == "Gunman")
			{
				PlayerPrefs.SetInt("life",100);
			}
			else if(PlayerPrefs.GetString("Char") == "Mage")
			{
				PlayerPrefs.SetInt("life",150);
			}
		}
		
	}
	//makes the gui that is funtamental of menu
	void OnGUI() {
		GUI.Label(new Rect(Screen.width / 2 - 100, -30, 200, 100), "SchoolProject");
		menuFunction();
	}
	void anyKey() {
		if(Input.anyKey){
			menuFunction = mainMenu;
			
		}
		//label values for placing the buttons onto.
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(screenWidth * 0.45f, screenHeight  * 0.45f, screenWidth * 0.1f, screenHeight * 0.1f), "press any key ");
	}
	//makes the 3 buttons. 
	void mainMenu(){
		if (GUI.Button(new Rect((screenWidth - buttonWidth) * 0.9f, screenHeight * 0.2f, buttonWidth, buttonHeigth), "Start game")){
			Application.LoadLevel(1);
			//Start game
		}
		if (GUI.Button(new Rect((screenWidth - buttonWidth) * 0.9f, screenHeight * 0.4f, buttonWidth, buttonHeigth), "Highscore"))
		{
			Application.LoadLevel(6);
			//Loads Highscore
		}
		if (GUI.Button(new Rect((screenWidth - buttonWidth) * 0.9f, screenHeight * 0.6f, buttonWidth, buttonHeigth), "Quit"))
		{
			Application.Quit();
			// Quit game
		}
	}
}