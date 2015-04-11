using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
	Player player;

	void Start(){
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		
		player = p.GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.tag);
		if (other.tag == "Player") {
			player.HP -= 1;
			Debug.Log(player.HP);
		}
	}


}
