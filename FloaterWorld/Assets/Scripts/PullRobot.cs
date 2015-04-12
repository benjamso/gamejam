using UnityEngine;
using System.Collections;

public class PullRobot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

    public float pullRadius = 0.1f;
    public float pullForce = 1f;
	public float pullSpeedFactor  = 1.0f;
	private bool trykker = false;
}
//     public void FixedUpdate() {
//		if (Input.GetKeyDown (KeyCode.X)) {
//			trykker = true;
//		}
//		if (Input.GetKeyUp (KeyCode.X)) {
//			trykker = false;
//		}
//
//		if(trykker){
//         foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, pullRadius)) {
//             // calculate direction from target to me
//
//				if(collider.gameObject.tag == "Player"){
//					Debug.Log (gameObject.name + " fant " + collider.gameObject.name);
//					Debug.Log("Fant Spiller" + gameObject.name);
//				 	  Vector3 diff = transform.position - collider.gameObject.transform.position;
//					//collider.gameObject.transform.position += diff / diff.magnitude * pullSpeedFactor;
//
//
//
//					Rigidbody2D body = collider.gameObject.GetComponent<Rigidbody2D>();
//
//					var heading =  this.transform.position - body.transform.position;
//					
//					var distance = heading.magnitude;
//					var direction = heading / distance;
//
//					body.MovePosition(direction);
//
//						//AddForce((collider.gameObject.transform.position - transform.position).normalized * 1f);
//			}
//			}
//    }
//
//}
//}