using UnityEngine;
using System.Collections;

public class EnemyHitWall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			var ai = other.gameObject.GetComponent<SimpleEnemyAI>();

			ai.direction = ai.direction * -1;
		}
	}
}
