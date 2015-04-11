using UnityEngine;
using System.Collections;

public class FallThroughFloor : MonoBehaviour {

	public GameObject collider;
	private Collider2D col;
	
	private bool playerTouchesFloor;

	private System.DateTime tid;

	void Start () {
		this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
		col = collider.GetComponent<Collider2D> ();
		col.isTrigger = false;
	}
	
	void Update () {
		//Open floor when robot is above
		if (Input.GetKeyDown(KeyCode.DownArrow) && playerTouchesFloor){
			col.isTrigger = true;
			tid = System.DateTime.Now;
		}
		//Open floor when robot is under 
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			col.isTrigger = true;
			tid = System.DateTime.Now;
		}
		//Close floor
		if ((System.DateTime.Now - tid).TotalMilliseconds >= 500) {
			col.isTrigger = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		playerTouchesFloor = true;

	}
	
	void OnTriggerExit2D(Collider2D other){
		playerTouchesFloor = false;
	}
}
