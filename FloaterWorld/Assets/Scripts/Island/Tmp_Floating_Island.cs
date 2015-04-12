using UnityEngine;
using System.Collections;

public class Tmp_Floating_Island : MonoBehaviour {

	private bool playerTouchesFloor;

	void Start () {
		playerTouchesFloor = false;
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		playerTouchesFloor = true;
		
	}
	
	void OnTriggerExit2D(Collider2D other){
		playerTouchesFloor = false;
	}
}
