using UnityEngine;
using System.Collections;

public class TimeactivatedFloor : MonoBehaviour {


	public bool StartEnabled;

	private float StartTime;
	private bool active;
	private float nextSwitch;

	public float activeTime;
	public float deactivatedTime;

	public GameObject collider;
	private Collider2D col;


	public GameObject OffRed;
	public GameObject OnRed;
	public GameObject OffGreen;
	public GameObject OnGreen;

	private Renderer OffRedRenderer;
	private Renderer OnRedRenderer;
	private Renderer OffGreenRenderer;
	private Renderer OnGreenRenderer;


	// Use this for initialization
	void Start () {
	
		this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
		col = collider.GetComponent<Collider2D> ();
		col.isTrigger = false;

		OffRedRenderer = OffRed.GetComponent<Renderer> ();
		OnRedRenderer = OnRed.GetComponent<Renderer> ();
		OffGreenRenderer = OffGreen.GetComponent<Renderer> ();
		OnGreenRenderer = OnGreen.GetComponent<Renderer> ();

		OffRedRenderer.enabled = false; 
		OnRedRenderer.enabled = false; 
		OffGreenRenderer.enabled = false;
		OnGreenRenderer.enabled = false;

		StartTime = Time.time;
		if (StartEnabled) {
			OnGreenRenderer.enabled = true;
			nextSwitch = StartTime + activeTime;
		} else {
			OffRedRenderer.enabled = true;
			nextSwitch = StartTime + deactivatedTime;
		}

		active = StartEnabled;
	}

	void Update () {

		if (active && (Time.time > (nextSwitch - 0.5f))) {
			OnRedRenderer.enabled = true;
			OnGreenRenderer.enabled = false;
			//LightRenderer.material.color = new Color (255, 0, 0);
		}
		if (!active && (Time.time > (nextSwitch - 0.5f))) {
			//LightRenderer.material.color = new Color (0, 255, 0);
			OffGreenRenderer.enabled = true;
			OffRedRenderer.enabled = false;
		}

		 if (active && ( Time.time> nextSwitch )) {
			active = false;
			col.isTrigger = true;
			nextSwitch = Time.time + deactivatedTime;
			OffRedRenderer.enabled = true;
			OnRedRenderer.enabled = false;
		}

		if (!active && ( Time.time> nextSwitch )) {
			active = true;
			col.isTrigger = false;
			nextSwitch = Time.time + activeTime;
			OnGreenRenderer.enabled = true;
			OffGreenRenderer.enabled = false;
		}
	}
}
