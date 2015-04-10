using UnityEngine;
using System.Collections;

public class SimpleEnemyAI : MonoBehaviour {

	public float Speed;
	public int direction = 1;
	public float moveLength;
	private float increment;
	private float initialX;


	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();//.velocity = transform.right * Speed;
		initialX = body.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		increment += (Speed / 100) * direction;

		Vector3 pos = transform.position;
		pos.x = Mathf.PingPong(Time.time*2, moveLength) + initialX;
		transform.position = pos;

	}
}
