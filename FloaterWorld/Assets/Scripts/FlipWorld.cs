using UnityEngine;
using System.Collections;

public class FlipWorld : MonoBehaviour {
	public GameObject TheWorld;
	// Use this for initialization
	public bool IsFlipped = false;
	public bool FlippIt = false;

	private Transform trans;

	void Start () {
		trans = TheWorld.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (FlippIt && !IsFlipped) {
			trans.Rotate(0,0,(Time.deltaTime*3) * -1);
			if(trans.rotation.z <= -0.7f){
				IsFlipped = true;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && !IsFlipped) {
			FlippIt = true;
		}
	}
}
