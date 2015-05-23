using UnityEngine;
using System.Collections;

public class AccelerometerProcessor : MonoBehaviour {

	public GameObject eventSource;


	// Use this for initialization
	void Start () {
	
		var scraper = eventSource.GetComponent<InputAccelerometer>();
		scraper.changeEvent += localProgress;
		
		scraper.eventHandler.goodEvent += localGoodAchievement;
		scraper.eventHandler.superEvent += localSuperAchievement;
	}
	
	public void localProgress(){
	
		print("change!");
	}
	
	public void localGoodAchievement(){
		
		print("local good!");
	}
	
	public void localSuperAchievement(){
		
		print("local super!");
	}
}
