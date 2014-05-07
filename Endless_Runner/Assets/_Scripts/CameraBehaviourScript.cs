using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour {

	public int movement = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector2 (movement * Time.deltaTime, 0));
	
	}
}
