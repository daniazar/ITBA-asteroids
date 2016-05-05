using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {

	public Texture backgroundTexture;
	public float maxTime = 4;
	private float time =0;
	public GUISkin skin;

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height ), backgroundTexture);	
		GUI.Label(new Rect(1, 5, 240, 20), "Your Score: " + PlayerController.score.ToString(), skin.GetStyle("LoseSkin"));
		time += Time.deltaTime;

		if(Input.anyKeyDown  && time > maxTime)
		{
			
			PlayerController.lives = 3;
			PlayerController.score = 0;
			EnemyManager.enemyCount = 0;
			SceneManager.LoadScene("playScene");
		}
	}
		
	
}