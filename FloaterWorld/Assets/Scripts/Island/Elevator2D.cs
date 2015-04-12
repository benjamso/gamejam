using UnityEngine;
using System.Collections;

public class Elevator2D : MonoBehaviour {

	public GameObject XandYfor3DISland;
	// Use this for initialization
	private bool playerTouchesFloor = false;
	public bool Switch = false;
	public float Speed;


	void FixedUpdate(){

		// dersom player er på ingneting skjer...
		// dersom player er av og følg 3d platformen

		if(!playerTouchesFloor){
			float tmpX = XandYfor3DISland.transform.position.x;
			float tmpY = XandYfor3DISland.transform.position.y;

			Vector2 v = new Vector2(tmpX, tmpY);

			transform.position = Vector2.MoveTowards (transform.position, v, Speed);
		}

	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		playerTouchesFloor = true;
		Switch = false;
	}
	void OnTriggerExit2D(Collider2D other){
		playerTouchesFloor = false;
	}
}
