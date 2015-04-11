using UnityEngine;
using System.Collections;

public class Despawn2D : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
	}
}
