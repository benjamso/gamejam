using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public Text HUDText;


	public int HP = 5;

	// Use this for initialization
	void Start () {
		HUDText.text = "HP: " + HP;
	}
	
	// Update is called once per frame
	void Update () {
		HUDText.text = "HP: " + HP;
	}
}
