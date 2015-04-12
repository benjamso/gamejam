using UnityEngine;
using System.Collections;

public class SimpleEnemyAI : MonoBehaviour {

	public float Speed;
	public float moveLength;
	public int direction = -1;
	private float initialX;
	private bool facingRight;
	
	private Rigidbody2D body;
	void Start () {
		body = GetComponent<Rigidbody2D>();
		initialX = body.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x = (Mathf.PingPong(Time.time, moveLength) * direction) + initialX;

		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D other){
		direction = direction * -1;
	}

}
