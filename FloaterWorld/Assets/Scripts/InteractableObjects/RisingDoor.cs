using UnityEngine;
using System.Collections;

public class RisingDoor : MonoBehaviour {


	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	private bool open = false;
	public bool active = true;
	public RisingDoor otherTrigger;

	public GameObject Door;
	// Use this for initialization
	void Start () {
		journeyLength = Vector3.Distance(Door.transform.position, Door.transform.position);
		active = true;
	}


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("trig " + other.tag);
		if (active && other.tag == "Player") {
			startTime = Time.time;
			open = true;

			Door.transform.position = Vector3.Lerp (Door.transform.position, 
			                                        new Vector3(Door.transform.position.x,
													            Door.transform.position.y + 30,
													            Door.transform.position.z)
			                                        , Time.deltaTime * 2);
			active = false;
			otherTrigger.active = false;
		}
	}
}
