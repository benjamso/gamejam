using UnityEngine;
using System.Collections;

public class PickupTime : MonoBehaviour {

	public GameObject Self;
	private IslandTimer timer;

	void Start(){
		var obj = GameObject.Find ("HUD");
		timer = obj.GetComponent<IslandTimer>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Destroy(Self);
			timer.UpdateTimeLeft(20.0f);
		}
	}
}
