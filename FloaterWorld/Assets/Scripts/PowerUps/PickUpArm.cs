using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class PickUpArm : MonoBehaviour {

	public GameObject Self;
	private Platformer2DUserControl script;

	void Start(){
		var obj = GameObject.Find ("Player");
		script = obj.GetComponent<Platformer2DUserControl>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Destroy (Self);
			script.hasMagneticArm = true;
		}
	}
}
