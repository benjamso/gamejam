using UnityEngine;
using System.Collections;

public class Tmp_Floating_Island{

	private bool playerTouchesFloor;
	private GameObject test;
	private Collider2D col;

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
