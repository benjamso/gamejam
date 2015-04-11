using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public bool CanTeleport;
	public GameObject Player;


	void OnTriggerEnter2D(Collider2D other){
		CanTeleport = true;
	}
	
	void OnTriggerExit2D(Collider2D other){
		CanTeleport = false;
	}


	void Update(){


		if(CanTeleport && Input.GetKeyDown(KeyCode.E)){
			Player.transform.position = new Vector3(0.96f,1.33f,0f);
		}
	}

}
