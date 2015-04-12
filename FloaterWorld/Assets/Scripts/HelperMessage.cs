using UnityEngine;
using System.Collections;

public class HelperMessage : MonoBehaviour {

	public GameObject Message;

	private Renderer MessageRenderer;
	bool seen = false;
	// Use this for initialization
	void Start () {
		MessageRenderer = Message.GetComponent<Renderer> ();
		MessageRenderer.enabled = false;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && !seen) {
			MessageRenderer.enabled = true;
			seen = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			MessageRenderer.enabled = false;
		}
	}
}
