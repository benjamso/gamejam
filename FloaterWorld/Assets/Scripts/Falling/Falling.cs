using UnityEngine;
using System.Collections;

public class Falling : MonoBehaviour {

	// Denne klassen skal:
	// 		sjekke om Player er inne et spesifikt område
	//    	ta seg av å finne random points å spawne fra
	//		kalle på random fallende objekt

	private bool Inside;
	private float time;
	public float spawnTime = 1f;

	public GameObject Kule;
	public GameObject Capsule;
	

	// Use this for initialization
	void Start () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Inside && time+spawnTime < Time.time){
			//float pos = Random.Range (-10, 10);
			//float obj = Random.Range (0, 3);
			time = Time.time;
			spawnFallingObj();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("trig " + other.tag);
		if (other.tag == "Player") {
			Inside = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("trig " + other.tag);
		if (other.tag == "Player") {
			Inside = false;
		}
	}

	private void spawnFallingObj(){
		var obj = Random.Range(0, 2);
		float pos = Random.Range(-5, 5);
		switch(obj){
			case(0):
			Instantiate(Kule, new Vector3(pos,10.258558f,10f), Quaternion.identity);
			break;

		case(1):
			Instantiate(Capsule, new Vector3(pos,10.258558f,10f), Quaternion.identity);
			break;

		case(2):

			break;
		}

	}

}
