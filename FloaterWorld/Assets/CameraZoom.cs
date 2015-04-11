using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public int zoom  = 6; 
	public int normal  = 5;
	public float smooth = 5f; 
	private bool isZoomed = false; 
	private Camera camera;

	void Start(){
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("z")) { 
			isZoomed = true; 
		} 
		if(Input.GetKeyUp("z")){
			isZoomed = false;
		}
			
			if(isZoomed == true){
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize,zoom,Time.deltaTime*smooth);
			}else{
			 camera.orthographicSize = Mathf.Lerp(camera.orthographicSize,normal,Time.deltaTime*smooth);
			}

	}
}
