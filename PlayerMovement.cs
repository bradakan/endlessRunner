using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	bool playerJump;
	float gravitiScale = 5;
	float jumpForce = 1000;
	// Use this for initialization
	void Start () 
	{
		playerJump = false;
		rigidbody2D.gravityScale = gravitiScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x <= 0)
		{
			transform.Translate(1 * Time.deltaTime,0,0);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(playerJump == false && rigidbody2D.gravityScale == gravitiScale)
			{
				rigidbody2D.AddForce(new Vector2(0,jumpForce));
				playerJump = true;
			}
			if(playerJump == false && rigidbody2D.gravityScale == -gravitiScale)
			{
				rigidbody2D.AddForce(new Vector2(0,-jumpForce));
				playerJump = true;
			}
		}
		if(Input.GetKeyDown (KeyCode.W))
		{
			if(rigidbody2D.gravityScale == gravitiScale)
			{
				rigidbody2D.gravityScale = -gravitiScale;
			}
			else{rigidbody2D.gravityScale = gravitiScale;}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		playerJump = false;
	}
}
