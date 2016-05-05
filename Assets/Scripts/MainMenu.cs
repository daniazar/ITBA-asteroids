using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GUISkin skin;
	private string instructionText = "Instructions:\nPress Left, Right and Up to move.\nPress Spacebar to fire.\nTo win you need to score more than 5000 points.";
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 300;
	private int groupHeight = 450;
	
	
	void OnGUI()
	{
			GUI.Label(new Rect(Screen.width / 2 - groupWidth / 2 + 10, 10, 300, 200 ), instructionText);
			GUI.Box (new Rect (Screen.width / 2 - groupWidth / 2, Screen.height / 2 - groupHeight / 2 , groupWidth, groupHeight), "", GUI.skin.GetStyle("box"));
	        GUI.Label (new Rect (groupWidth/2 + 60, Screen.height/4 , groupWidth, groupHeight), "Asteroid Deluxe", skin.GetStyle("LoseSkin"));
           	if(GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 2 - buttonHeight / 2 , buttonWidth, buttonHeight), "Start Normal Game "))
			{
			SceneManager.LoadScene("playScene");
			}
			if(GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, Screen.height / 2 - buttonHeight / 2  + 2 * buttonHeight, buttonWidth, buttonHeight), "Start 2.5D Game"))
			{
			SceneManager.LoadScene("SceneName");
			}
    	
	}	
}
