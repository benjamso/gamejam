﻿using UnityEngine;
using System.Collections;

public class Tmp_Floating_Island : MonoBehaviour {

	private bool playerTouchesFloor;

	private Vector3 startPos;

	public GameObject collider;
	private Collider2D col;
	private Transform trans;

	private System.DateTime tid;

	private float speed;

	void Start () {
		playerTouchesFloor = false;
		trans = gameObject.GetComponent<Transform> ();
		startPos = trans.position;
		gameObject.GetComponent<Collider2D> ().isTrigger = true;
		col = collider.GetComponent<Collider2D> ();
		col.isTrigger = false;

		speed = 1.0f * Time.deltaTime;
	}

	void Update () {

		//Fallthrough
		if(playerTouchesFloor && Input.GetKeyDown(KeyCode.DownArrow)) {
			col.isTrigger = true;
			tid = System.DateTime.Now;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			col.isTrigger = true;
			tid = System.DateTime.Now;
		}
		if ((System.DateTime.Now - tid).TotalMilliseconds >= 500) {
			col.isTrigger = false;
		}

		if (!playerTouchesFloor) {
			transform.position = Vector3.MoveTowards(transform.position, startPos, speed);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		playerTouchesFloor = true;
	}
	
	void OnTriggerExit2D(Collider2D other){
		playerTouchesFloor = false;
	}
}
