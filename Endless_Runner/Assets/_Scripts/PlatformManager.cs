using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public GameObject runnerRef;
	public float distanceToRecycle = 0;
	public int numberOfPlatforms = 5;
	
	public List<GameObject> platforms = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		GameObject platformPrefab = Resources.Load ("Prefabs/Platform") as GameObject;

		for (int i=0; i<numberOfPlatforms; i++) {
			GameObject g = Instantiate(platformPrefab,Vector3.zero,Quaternion.identity) as GameObject;
				

			Vector3 tempPos = new Vector3();
			if(platforms.Count>0){
				tempPos = platforms[platforms.Count-1].transform.position;
				tempPos.x += g.transform.localScale.x*.5f;
			}

			g.transform.position = tempPos;
			g.transform.parent = gameObject.transform;
			platforms.Add(g);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (platforms [0].transform.position.x + distanceToRecycle < runnerRef.transform.position.x) {
			GameObject g = platforms[0];
			platforms.Remove(g);


			Vector3 tempPos = new Vector3();
			if(platforms.Count>0){
				tempPos = platforms[platforms.Count-1].transform.position;
				tempPos.x += g.transform.localScale.x*.5f;
			}
			
			g.transform.position = tempPos;
			g.transform.parent = gameObject.transform;
			platforms.Add(g);
		}
	}
}
