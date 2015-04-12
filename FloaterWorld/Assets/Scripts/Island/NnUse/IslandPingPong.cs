using UnityEngine;
using System.Collections;

public class SmallIslandFloati : MonoBehaviour {
	
	
	private bool playerTouchesFloor;
	
	public Transform DieZone;
	public Transform HomeSpot;
	//public GameObject DieZone;
	//private Transform dieZoneTrans;
	//private Vector3 HomeSpot;
	//private Vector3 DieZone;
	//public GameObject HomeSpot;
	//private Transform HomeSpotTrans;
	public float Speed;
	public bool Switch = false;
	
	//private bool playerTouchesFloor;
	void Start(){
		//dieZoneTrans = DieZone.GetComponent<Transform> ();
		//HomeSpotTrans = HomeSpot.GetComponent<Transform> ();
		//trans = GetComponent<Transform> ();
		//DieZone = new Vector3 (transform.position.x, -5, 0);
		//HomeSpot = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	void FixedUpdate(){
		
		/*if(HomeSpot.position == transform.position){
			Switch = true;
		}
		if(DieZone.position == transform.position){
			Switch = false;
		}*/
		
		
		//if (Switch) {
		//transform.position = Vector3.MoveTowards(transform.position, DieZone.position, Speed);
		transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
		//} else {
		//transform.position = Vector3.MoveTowards(transform.position, HomeSpot.position, Speed);
		//transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
		//}
		
	}
	
	
	
	void OnTriggerEnter2D(Collider2D other){
		playerTouchesFloor = true;
		
	}
	
	void OnTriggerExit2D(Collider2D other){
		playerTouchesFloor = false;
	}
	
	
}
