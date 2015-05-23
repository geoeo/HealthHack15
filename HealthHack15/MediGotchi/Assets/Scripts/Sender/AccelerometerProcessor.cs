using UnityEngine;
using System.Collections;

public class AccelerometerProcessor : MonoBehaviour {

	public GameObject input;

	// Use this for initialization
	void Start () {
	
		var scraper = input.GetComponent<InputAccelerometer>();
		scraper.changeEvent += localAchievement;
	
	}
	
	public void localAchievement(){
	
		print("change!");
	}
}
