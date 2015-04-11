using UnityEngine;
using System.Collections;

public class Despawn2D : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel (Application.loadedLevelName);
		} else {
			Destroy (other.gameObject);
		}
	}
}
