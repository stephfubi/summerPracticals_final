using UnityEngine;
using System.Collections;

public class DelegateMenu : MonoBehaviour 
{
	private delegate void MenuDelegate();
	private MenuDelegate menuFunction;

	private float screenHeight;
	private float screenWidth;
	

	// Use this for initialization
	void Start ()
	{
		screenHeight = Screen.height;
		screenWidth = Screen.width;
	
		menuFunction = anyKey;
	}
	
	
	void OnGUI ()
	{
		menuFunction();
	}

	
	void anyKey ()
	{
		if (Input.anyKey) 
		{
			menuFunction = mainMenu;
		}
		
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect (screenWidth * 0.45f, screenHeight * 0.45f, screenWidth * 0.1f, screenHeight * 0.1f), "Press any key to continue");
		
	}


	void mainMenu () 
	{
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		if(GUI.Button(new Rect(screenWidth  * 0.45f, screenHeight  * 0.45f, 120, 30), "Start new game"))
		{
			Application.LoadLevel("level 1");
		}
		
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		if(GUI.Button(new Rect(screenWidth  * 0.45f, screenHeight * 0.6f, 120, 30), "Exit game"))
		{
			Application.Quit();
		}
		
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
