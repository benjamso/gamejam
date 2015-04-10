using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IslandTimer : MonoBehaviour {
	public float TimeLeft;
	public float StartTime = 50.0f;
	public float MaxTime;

	public Slider IslandLeft;
	public Slider IslandRigth;



	// Use this for initialization
	void Start () {
		TimeLeft = StartTime;
		MaxTime = StartTime;
	}
	
	// Update is called once per frame
	void Update () {

		TimeLeft -= Time.deltaTime;

		float remaining =  (TimeLeft / MaxTime) * 100;
	
		IslandLeft.value = remaining;
		IslandRigth.value = remaining;

		if (TimeLeft <= 0) {
			//GameOver
		}
	}

	public void UpdateTimeLeft(float plussTime){
		TimeLeft += plussTime;

		if (TimeLeft > MaxTime) {
			MaxTime = TimeLeft;
		}
		float remaining =  (TimeLeft / MaxTime) * 100;
		
		IslandLeft.value = remaining;
		IslandRigth.value = remaining;
	}

}
