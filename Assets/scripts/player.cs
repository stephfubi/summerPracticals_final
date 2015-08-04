using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	//move the player using the mouse
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		transform.position = new Vector3(transform.position.x, transform.position.y, ray.GetPoint(18).z);
		
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		
	}
}
