using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
	
	public Vector3 InitialImpulse;
	public int Invert;
	public int TowardsPlayer;
	
	
	public int PlayerScore = 0;
	public int EnemyScore = 0;
	public int winningScore = 5;
	public GUIText score_Text;
	
	
	public ScoreUI score;
	
	
	// Use this for initialization
	void Start () 
	{
		rigidbody.AddForce(InitialImpulse, ForceMode.Impulse);
		Invert = 1;
		TowardsPlayer = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < -8.5f ) 
		{
			GameObject.Find("Main Camera").GetComponent<ScoreUI>().IncreaseScore(1);
			
			transform.position = new Vector3(0f, 1f, 0f);
			
			//rigidbody.velocity = new Vector3(8.0f, 0.0f, -8.0f*Invert);
		}
		
		
		if (transform.position.x > 8.5f) 
		{
			
			GameObject.Find("Main Camera").GetComponent<ScoreUI>().IncreaseScore(2);
			
			transform.position = new Vector3(0f, 1f, 0f);
			
			//rigidbody.velocity = new Vector3(8.0f, 0.0f, -8.0f*Invert);
		}
		
		
	}
	
	
	//collision detection
	void OnCollisionEnter(Collision collision)
	{
		ball ball = collision.gameObject.GetComponent<ball>();
		
		if(ball != null)
		{
		
			if (collision.gameObject.name == "wall") 
			{
				Invert = Invert *  -1;
			
				rigidbody.velocity = new Vector3(-8.0f*TowardsPlayer, 0.0f, -8.0f*Invert);
				
			}
			
			else if(collision.gameObject.name == "player")
			{
				TowardsPlayer = 1;
				
				rigidbody.velocity = new Vector3(-9.0f*TowardsPlayer, 0.0f, -9.0f*Invert);
				
			}
			
			else if(collision.gameObject.name == "enemy") 
			{
				TowardsPlayer = -1;
				
				rigidbody.velocity = new Vector3(-8.0f*TowardsPlayer, 0.0f, -8.0f*Invert);
			
		     }
			
		}
	}
	
	
}
