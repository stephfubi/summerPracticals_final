using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour 
{
	public float speed = 5f;

	private Transform ballTransform;

	void Start()
	{
		// find reference for the ball
			GameObject ballGameObject = GameObject.Find("Ball");
		
			if (ballGameObject == null)
			{
				Debug.LogWarning("PlayerAI cannot find Ball.");
				enabled = false;
			}
			else
			{
				ballTransform = ballGameObject.transform;
			}
	}

		
	// Updates the player position.
			
	void FixedUpdate () 
	{
		// input speed of the AI from -1 to 1
		float inputSpeed = 0f;

		if (ballTransform.position.z > transform.position.z)
		{
			inputSpeed = 1.0f;
		}
		else if (ballTransform.position.z < transform.position.z)
		{
			inputSpeed = -1.0f;
		}
			
		// move player along the x axis
		Vector3 position = transform.position + new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);

		
		// If the ball speed along the z-axis is smaller than the ball speed, the player will lag.
		// We can prevent the lagging by clamping the z-position to the ball position.
		if (inputSpeed > 0f)
		{
			if (position.z > ballTransform.position.z)
				{
					position.z = ballTransform.position.z;
				}
		}
		
		
		else if (inputSpeed < 0f)
		{
			if (position.z < ballTransform.position.z)
				{
					position.z = ballTransform.position.z;
				}
		}

		transform.position = position;
	}


}



