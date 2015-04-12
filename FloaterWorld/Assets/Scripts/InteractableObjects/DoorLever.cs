using UnityEngine;
using System.Collections;

public class DoorLever : MonoBehaviour {
	public float halfSideLength;

	private bool open = false;
	public bool active = true;

	public GameObject cube;
	public GameObject DoorlLight;
	
	public GameObject Door;
	public GameObject DoorOpen;

	private Renderer doorRenderer;
	private Renderer doorOpenRenderer;

	private bool Inside = false;

	// Use this for initialization
	void Start () {
		active = true;
		doorRenderer = Door.GetComponent<Renderer> ();
		 doorOpenRenderer = DoorOpen.GetComponent<Renderer> ();
		doorRenderer.enabled = true;
		doorOpenRenderer.enabled = false;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (active && other.tag == "Player") {
			Inside = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (active && other.tag == "Player") {
			Inside = false;
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.E) && Inside) {
			if(open){
				open = false;
				doorRenderer.enabled = true;
				doorOpenRenderer.enabled = false;
				Door.GetComponent<Collider2D> ().isTrigger = false;

				
				SetTriggerColor(new Color(255,0,0));

				transform.Rotate(Vector3.forward, -45.0f);
			}else{
				open = true;
				doorRenderer.enabled = false;
				doorOpenRenderer.enabled = true;
				Door.GetComponent<Collider2D> ().isTrigger = true;
				
				SetTriggerColor(new Color(0,255,0));

				transform.Rotate(Vector3.forward, 45.0f);
			}
		}
	}

	public void SetTriggerColor(Color c){
		
		Renderer ren = cube.GetComponent<Renderer> ();
		ren.material.color = c;
		
		if (DoorlLight != null) {
			Renderer li = DoorlLight.GetComponent<Renderer> ();
			li.material.color = c;
		}
	}
}
