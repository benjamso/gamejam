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
	private float nextSwitch;

	public float activeTime;
	public float deactivatedTime;

	public GameObject collider;
	private Collider2D col;
	public GameObject Light;
	private Renderer LightRenderer;

	// Use this for initialization
	void Start () {
		renderer = plane.GetComponent<Renderer> ();
		this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
		col = collider.GetComponent<Collider2D> ();
		col.isTrigger = false;
		LightRenderer = Light.GetComponent<Renderer> ();

		StartTime = Time.time;
		if (StartEnabled) {
			renderer.material.color = EnabledColor;
			nextSwitch = StartTime + activeTime;
		} else {
			renderer.material.color = DeactivatedColor;
			nextSwitch = StartTime + deactivatedTime;
		}

		active = StartEnabled;
	}

	void Update () {

		if (active && (Time.time > (nextSwitch - 0.5f))) {
			LightRenderer.material.color = new Color (255, 0, 0);
		}
		if (!active && (Time.time > (nextSwitch - 0.5f))) {
			LightRenderer.material.color = new Color (0, 255, 0);
		}

		 if (active && ( Time.time> nextSwitch )) {
			active = false;
			col.isTrigger = true;
			nextSwitch = Time.time + deactivatedTime;

			renderer.material.color = DeactivatedColor;
			Debug.Log ("deaktiverer");
		}

		if (!active && ( Time.time> nextSwitch )) {
			active = true;
			col.isTrigger = false;
			nextSwitch = Time.time + activeTime;
			renderer.material.color = EnabledColor;
			Debug.Log ("aktiverer");
		}
	}
}
