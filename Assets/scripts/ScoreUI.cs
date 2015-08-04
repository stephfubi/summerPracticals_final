using UnityEngine;
using System.Collections;

public class ScoreUI : MonoBehaviour 
{
	
	public int scorePlayer;

	public int scoreEnemy;
	
	public GUISkin ScoreSkin;

	public int winningScore = 100;
	
	public GUIText message;

	public bool isPause;
	
	
	void start()
	{
		isPause = false;
	}
	
	
	 void Update()
	{
		if(isPause == true)
		{
			Time.timeScale = 0;
			if (Input.anyKey)
			{
				isPause = false;
				Time.timeScale = 1;
				
			}
		}
		 
	}
	
	
	void Awake()
	{
		message = GameObject.Find("GUI Text").GetComponent<GUIText>();
	}
	
	
	
	public void IncreaseScore(int PlayerType)
	{
		if (PlayerType == 2) 
		{
			scoreEnemy += 10;
			
			if(scoreEnemy < 100)
			{
				StartCoroutine(ShowMessage("Computer scored!!, press any key to continue", 2.0f));
			}
		} 
		
		
		else if (PlayerType == 1)
		{
			scorePlayer += 10;
			
			if(scorePlayer < 100)
			{
				StartCoroutine(ShowMessage("player scored!!, press any key to continue", 2.0f));
			}		
		} 
		isPause = true;
		
	}
	
	
	void OnGUI()
	{
		// calculate the top screen center of the screen
		float width = 300f;
		float height = 20f;
		
		if(GUI.skin != ScoreSkin)
		{
			GUI.skin  = ScoreSkin;
		}
		
		// draw the label at the top left of the screen
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.Label(new Rect(10,30,width,height), "Player : " + scorePlayer.ToString());
		GUI.Label(new Rect(10,60,width,height),"Computer : " + scoreEnemy.ToString());
		
		
		// check for winning condition
		if (scoreEnemy >= winningScore || scorePlayer >= winningScore)
		{
			// disable ball
			GameObject ball = GameObject.Find("Ball");
			if (ball != null)
			{
				ball.SetActive(false);
				player.Destroy(GameObject.Find("player"));
				player.Destroy(GameObject.Find("enemy")); 
			}

			// create winning message
			string winMessage = "Computer won!!";
			if (scorePlayer >= winningScore)
			{
				winMessage = "Player  won!!";
			}

			// show winning message at the center of the screen
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label(new Rect(Screen.width  * 0.45f, Screen.height  * 0.45f, Screen.width  * 0.1f, height), winMessage);
			
			//offer to replay
			if(GUI.Button(new Rect((Screen.width/2)-50,Screen.height * 0.6f, 100, height), "replay"))
			{
				Application.LoadLevel("level 1");
			}
			
			if(Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
			}
			
		}
		//exit and menu buttons
		const int buttonWidth = 80;
		const int buttonHeight = 20;
		
		// Determine the button's place on screen
		//exit button
		Rect buttonExit = new Rect(Screen.width - (buttonWidth),(Screen.height) - (buttonHeight),buttonWidth,buttonHeight);
		
		//main menu button
		Rect buttonMenu = new Rect(Screen.width*0.068f - (buttonWidth),(Screen.height) - (buttonHeight),buttonWidth,buttonHeight);
		
		// Draw a button to exit the game
		if (GUI.Button (buttonExit, "Quit game"))
		{
			// On Click, exit the game.
			Application.Quit();
		}
		//draw a button to go back to the game's main menu
		if (GUI.Button (buttonMenu, "Main menu"))
		{
			// On Click, exit the game.
			Application.LoadLevel("Delegate Menu");
		}
		
		//menu_Function();
		
	}
	
//	void Wait()
//	{
//     	Time.timeScale = 0.0f;
//		
//		if (Input.anyKey) 
//		{
//			Time.timeScale = 1.0f;
//		}
//		
//	}
	
	
	
	//GOAL NOTIFICATION
	IEnumerator ShowMessage(string str, float delay)
	{
		message.text = str;
		message.enabled = true;
		yield return new WaitForSeconds(delay);
		message.enabled = false;
		
	}
	
}