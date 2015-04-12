using UnityEngine;
using System.Collections;

public class PickupBluePrint : MonoBehaviour {

	public GameObject me;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Destroy (me);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
