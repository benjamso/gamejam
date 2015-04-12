using UnityEngine;
using System.Collections;

public class MovingPlatformZ : MonoBehaviour {
	public float moveLength;
	public int direction = -1;
	private float initialZ;
	// Use this for initialization
	void Start () {
	//	Rigidbody2D body = GetComponent<Rigidbody2D>();
	//	initialZ = body.position.y;
	}
	
	// Update is called once per frame
	void Update () {

	//	Vector3 pos = transform.position;
	//	pos.z = (Mathf.PingPong(Time.time, moveLength) * direction) + initialZ;
	//	transform.position = pos;
	}
}
