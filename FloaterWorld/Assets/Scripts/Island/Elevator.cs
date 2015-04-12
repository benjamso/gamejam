using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	public Transform DieZone;
	public Transform HomeSpot;
	public float Speed;
	public bool Switch = false;

	private bool playerTouchesFloor = false;

	public GameObject XandYfor2DIsland;


	void FixedUpdate(){

		//Nå skal denne fungere som heis som går fra to punkter satt opp mellom to like objekter. 

		if(transform.position == DieZone.position){
			Switch = true;
		}
		if(transform.position == HomeSpot.position){
			Switch = false;
		}


		if (Switch) {
			transform.position = Vector3.MoveTowards (transform.position, HomeSpot.position, Speed);
			
		} else {
			transform.position = Vector3.MoveTowards (transform.position, DieZone.position, Speed);

		}


	}
}

