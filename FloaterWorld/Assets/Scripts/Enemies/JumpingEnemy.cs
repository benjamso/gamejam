using UnityEngine;
using System.Collections;

public class JumpingEnemy : MonoBehaviour {
	[SerializeField]private float m_JumpForce = 400f; 
	[SerializeField]private float m_MaxSpeed = 5f;   
	private Rigidbody2D m_Rigidbody2D;

	private float JumpIntervall = 3.0f;
	private float lastJump;
	[SerializeField] private bool IsJumping = false;

	private bool CloseEnoughtToAttack = false;
	public float attackRange = 5.0f;

	public GameObject player;
	private Transform playerPos;

	// Use this for initialization
	void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		playerPos = player.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		var heading = playerPos.position - this.transform.position;

		var distance = heading.magnitude;
		var direction = heading / distance;

		if (distance < attackRange) {
			CloseEnoughtToAttack = true;
		} else {
			CloseEnoughtToAttack = false;
		}


		if (!IsJumping && CloseEnoughtToAttack) {
			lastJump = Time.time;
			IsJumping = true;
			m_Rigidbody2D.AddForce (new Vector2 (0f, m_JumpForce));
			m_Rigidbody2D.velocity = new Vector2((1.0f*m_MaxSpeed)*direction.x, m_Rigidbody2D.velocity.y);
		}

		if (lastJump + JumpIntervall < Time.time && IsJumping) {
			IsJumping = false;
		}
	}
}
