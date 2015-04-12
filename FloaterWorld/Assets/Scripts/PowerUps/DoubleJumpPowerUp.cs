using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class DoubleJumpPowerUp : MonoBehaviour {
	Player player;
	AudioSource m_PickupSound;
	[SerializeField] private bool m_PickedUp = false;
	private PlatformerCharacter2D script;

	// Use this for initialization
	void Start () {
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		
		player = p.GetComponent<Player>();

		m_PickupSound = GetComponent<AudioSource> ();
		var obj = GameObject.Find ("Player");
		script = obj.GetComponent<PlatformerCharacter2D>();

	}
	
	// Update is called once per frame
	void Update () {
		if (m_PickedUp && !m_PickupSound.isPlaying) {
			Object.Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Collision detected");
		if (other.tag == "Player") {
			Debug.Log("Player picked up power up");
			m_PickupSound.Play();
			m_PickedUp = true;
			script.GiveDoubleJump();
			//Object.Destroy(gameObject);
		}
	}
}
