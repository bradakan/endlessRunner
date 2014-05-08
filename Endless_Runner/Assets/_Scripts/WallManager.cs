using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallManager : MonoBehaviour 
{
	public GameObject runnerRef;
	public float distanceToRecycle = 20;
	public int numberOfWalls = 4;
	public int movement = -5;
	public List<GameObject> wall = new List<GameObject>();

	public GameObject[] wallCollection;

	static int randomWall = Random.Range(1,4);

	void Start () 
	{




		GameObject wallPrefab = Resources.Load ("Prefabs/Wall" + randomWall) as GameObject;
		for (int i=0; i<numberOfWalls; i++) 
		{
			GameObject b = Instantiate (wallPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			Vector3 tempPos = new Vector3();
			if(wall.Count>0)
			{
				tempPos = wall[wall.Count-1].transform.position;
				tempPos.x += b.transform.localScale.x*.5f*35;
			}
			b.transform.position = tempPos;
			b.transform.parent = gameObject.transform;
			b.transform.parent.localPosition = new Vector3(30,12,20);
			wall.Add(b);
		}
	}
	// Update is called once per frame
	void Update () {

		randomWall = Random.Range (1, 4);
		Debug.Log (randomWall);

		transform.Translate (new Vector2 (movement * Time.deltaTime, 0));

		if (wall [0].transform.position.x + distanceToRecycle < runnerRef.transform.position.x) 
		{
			GameObject b = wall[0];
			wall.Remove(b);


			GameObject wallPrefab = Resources.Load ("Prefabs/Wall" + Random.value * 2 + 1) as GameObject;


			Vector3 tempPos = new Vector3();
			if(wall.Count>0)
			{
				tempPos = wall[wall.Count-1].transform.position;
				tempPos.x += b.transform.localScale.x*.5f*35;
			}
			b.transform.position = tempPos;
			b.transform.parent = gameObject.transform;
			//b.transform.parent.localPosition = new Vector3(30,12,20);
			wall.Add(b);
		}
	}
}