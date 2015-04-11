using UnityEngine;
using System.Collections;
using System;

public class TimeactivatedFloor : MonoBehaviour {


	public bool StartEnabled;
	public Color EnabledColor;
	public Color DeactivatedColor;
	public GameObject plane;
	private Renderer renderer;
	private DateTime StartTime;
	private bool active;

	public float activeTime;
	public float deactivatedTime;
	// Use this for initialization
	void Start () {
		renderer = plane.GetComponent<Renderer> ();
		if (StartEnabled) {
			renderer.material.color = EnabledColor;
		} else {
			renderer.material.color = DeactivatedColor;
		}
		StartTime = DateTime.Now;
		active = StartEnabled;
	}

	void Update () {
		
	}
}
