using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnLocation(int x){
		float deltaX = x;
		float deltaY = 7.2f;

		Vector2 finalTransform = new Vector2(deltaX, deltaY);
		transform.Translate (finalTransform);
	}

}
