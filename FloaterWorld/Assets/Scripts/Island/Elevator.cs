using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	//public Transform DieZone;
	//public Vector3 HomeSpot;
	public Transform HomeSpot;
	public float Speed;
	public bool Switch = false;

	private bool playerTouchesFloor = false;

	//public float xValue2D;
	//public float yValue2D;
	public GameObject XandYfor2DIsland;

	//private bool playerTouchesFloor;
	

	void FixedUpdate(){

		//dersom min fart == 0, og min posisjon ikkje er i homeZone Så sett true og fly til HomeZone
		// ellers dersom false Så do nothing?



		if(transform.position != HomeSpot.position && !playerTouchesFloor ){
			Switch = true;
		}
		if(transform.position == HomeSpot.position){
			Switch = false;
		}


		if (Switch) {
			transform.position = Vector3.MoveTowards (transform.position, HomeSpot.position, Speed);
			
		} else {
			float tmpX = XandYfor2DIsland.transform.position.x;
			float tmpY = XandYfor2DIsland.transform.position.y;
			Vector3 v = new Vector3(tmpX, tmpY, 0);
			transform.position = Vector3.MoveTowards (transform.position, v, Speed);

		}


	}


	/*
	// Use this for initialization
	void Start () {
		playerTouchesFloor = false;

		Origin = transform.position;
		Speed = 0.5f;
		v = new Vector3(transform.position.x, 5, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Her " +transform.position.y);
		// if playaer pos er oppå
		// Else if this pos != origin


		if(playerTouchesFloor){
			Debug.Log ("floor " +transform.position.y);
			transform.position = Vector3.MoveTowards(transform.position, v, Speed);

		}else if(transform.position == Origin){
			transform.position = Vector3.MoveTowards(transform.position, Origin, Speed);
		}
	}

	*/
	void OnTriggerEnter2D(Collider2D other){
		playerTouchesFloor = true;
		Switch = false;
	}
}

