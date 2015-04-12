using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public bool CanTeleport;
	public GameObject Player;
	private Vector3 startpos;

	void Start(){
		startpos = Player.transform.position;
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			CanTeleport = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			CanTeleport = false;
		}
	}


	void Update(){


		if(CanTeleport && Input.GetKeyDown(KeyCode.E)){
			Player.transform.position = startpos;
		}
	}

}
