using UnityEngine;
using System.Collections;

public class DoorLever : MonoBehaviour {
	public float halfSideLength;

	Transform pivot;
	
	private float journeyLength;
	private bool open = false;
	public bool active = true;

	public GameObject cube;
	public GameObject DoorlLight;
	
	public GameObject Door;

	private bool Inside = false;

	// Use this for initialization
	void Start () {
		//pivot.position.y = transform.position.y - halfSideLength;
		//
		journeyLength = Vector3.Distance(Door.transform.position, Door.transform.position);
		active = true;
		closedPos = Door.transform.position.y;
		openPos = closedPos + 30;
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
			if(open){
				open = false;
				
				Door.transform.position = Vector3.Lerp (Door.transform.position, 
				                                        new Vector3(Door.transform.position.x,
				            Door.transform.position.y - 30,
				            Door.transform.position.z)
				                                        , Time.deltaTime *2);
				
				SetTriggerColor(new Color(255,0,0));
				
				active = false;
				transform.Rotate(Vector3.forward, -45.0f);
			}else{
				open = true;
				
				Door.transform.position = Vector3.Lerp (Door.transform.position, 
				                                        new Vector3(Door.transform.position.x,
				            Door.transform.position.y + 30,
				            Door.transform.position.z)
				                                        , Time.deltaTime * 2);
				
				SetTriggerColor(new Color(0,255,0));
				
				active = false;
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
