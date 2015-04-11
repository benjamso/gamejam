using UnityEngine;
using System.Collections;

public class TimeactivatedFloor : MonoBehaviour {


	public bool StartEnabled;
	public Color EnabledColor;
	public Color DeactivatedColor;
	public GameObject plane;
	private Renderer renderer;
	private float StartTime;
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
		StartTime = Time.time;
		active = StartEnabled;
	}

	void Update () {
		 if (active && (StartTime + activeTime) > Time.time) {
			active = false;
			StartTime = Time.time;
			renderer.material.color = DeactivatedColor;
		}

		if (!active && (StartTime + deactivatedTime) > Time.time) {
			active = true;
			StartTime = Time.time;
			renderer.material.color = EnabledColor;
		}
	}
}
