using UnityEngine;
using System.Collections;

public class Despawn : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
	}

}
