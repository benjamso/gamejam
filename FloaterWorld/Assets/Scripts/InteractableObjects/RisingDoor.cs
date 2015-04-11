﻿using UnityEngine;
using System.Collections;

public class RisingDoor : MonoBehaviour {



	private float journeyLength;
	private bool open = false;
	public bool active = true;
	public RisingDoor otherTrigger;

	
	public GameObject cube;
	public GameObject DoorlLight;

	public GameObject Door;
	// Use this for initialization
	void Start () {
		journeyLength = Vector3.Distance(Door.transform.position, Door.transform.position);
		active = true;
	}


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("trig " + other.tag);
		if (active && other.tag == "Player") {
			open = true;

			Door.transform.position = Vector3.Lerp (Door.transform.position, 
			                                        new Vector3(Door.transform.position.x,
													            Door.transform.position.y + 30,
													            Door.transform.position.z)
			                                        , Time.deltaTime * 2);

			SetTriggerColor();
			if (otherTrigger != null) {
				otherTrigger.SetTriggerColor ();
				otherTrigger.active = false;
			}
			active = false;
			
		}
	}

	public void SetTriggerColor(){

			Renderer ren = cube.GetComponent<Renderer> ();
			ren.material.color = new Color (0, 255, 0);
		
		if (DoorlLight != null) {
			Renderer li = DoorlLight.GetComponent<Renderer> ();
			li.material.color = new Color (0, 255, 0);
		}
	}
}
	