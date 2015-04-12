using UnityEngine;
using System.Collections;

public class HatchLever : MonoBehaviour {

	public GameObject Hatch;
	public bool active = true;
	private bool Inside = false;
	public bool open = false;
	public GameObject cube;

	void Start () {
		active = true;
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

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && Inside) {
			if(open){
				open = false;
				
				Hatch.transform.Rotate(Vector3.right * Time.deltaTime);
				
				SetTriggerColor(new Color(255,0,0));
				
				Hatch.transform.Rotate(0f,0f,90f);
				transform.Rotate(Vector3.forward, -45.0f);
			}else{
				open = true;

				Hatch.transform.Rotate(Vector3.left * Time.deltaTime);

				Hatch.transform.Rotate(0f,0f,-90f);
				
				SetTriggerColor(new Color(0,255,0));
				
				transform.Rotate(Vector3.forward, 45.0f);
			}
		}
	}

	public void SetTriggerColor(Color c){
		
		Renderer ren = cube.GetComponent<Renderer> ();
		ren.material.color = c;
		
		//if (DoorlLight != null) {
		//	Renderer li = DoorlLight.GetComponent<Renderer> ();
		//	li.material.color = c;
		//}
	}
}
