using UnityEngine;
using System.Collections;

public class AccelerometerProcessor : MonoBehaviour {

	public GameObject eventSource;

	// Use this for initialization
	void Start () {
	
		var scraper = eventSource.GetComponent<InputAccelerometer>();
		scraper.changeEvent += localAchievement;
	
	}
	
	public void localAchievement(){
	
		print("change!");
	}
}
