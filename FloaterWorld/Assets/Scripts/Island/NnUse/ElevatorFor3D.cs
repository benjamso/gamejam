using UnityEngine;
using System.Collections;

public class ElevatorFor3D : MonoBehaviour {

	public Transform HomeSpot;
	public float Speed;
	public bool Switch = false;
	
	private bool playerTouchesFloor = false;

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
	void OnTriggerEnter2D(Collider2D other){
		playerTouchesFloor = true;
		Switch = false;
	}
	void OnTriggerExit2D(Collider2D other){
		playerTouchesFloor = false;
	}
}
