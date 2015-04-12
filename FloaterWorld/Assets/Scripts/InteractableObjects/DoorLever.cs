using UnityEngine;
using System.Collections;

public class DoorLever : MonoBehaviour {
	public float halfSideLength;

	private bool open = false;
	public bool active = true;

	public GameObject cube;
	public GameObject DoorlLight;
	
	public GameObject Door;

	private bool Inside = false;

	// Use this for initialization
	void Start () {
		active = true;
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("trig " + other.tag);
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
			Debug.Log ("Trykket E");
			if(open){
				open = false;
				
				Door.transform.position = Vector3.Lerp (Door.transform.position, 
				                                        new Vector3(Door.transform.position.x,
				            Door.transform.position.y - 15,
				            Door.transform.position.z)
				                                        , Time.deltaTime *2);
				
				SetTriggerColor(new Color(255,0,0));

				transform.Rotate(Vector3.forward, -45.0f);
			}else{
				open = true;
				
				Door.transform.position = Vector3.Lerp (Door.transform.position, 
				                                        new Vector3(Door.transform.position.x,
				            Door.transform.position.y + 15,
				            Door.transform.position.z)
				                                        , Time.deltaTime * 2);
				
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
