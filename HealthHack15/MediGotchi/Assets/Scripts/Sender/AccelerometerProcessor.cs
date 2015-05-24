using UnityEngine;
using System.Collections;

public class AccelerometerProcessor : MonoBehaviour {

	public GameObject eventSource;
	
	public GameObject localEvent;
	
	public GameObject localAchievement;
	
	float currentTime = 0;
	
	float timeout = 15;
	
	GameManager gm;


	// Use this for initialization
	void Start () {
	
		var scraper = eventSource.GetComponent<InputAccelerometer>();
		scraper.changeEvent += localProgress;
		
		scraper.eventHandler.goodEvent += localGoodAchievement;
		scraper.eventHandler.superEvent += localSuperAchievement;
		
		gm = localEvent.GetComponent<GameManager>();
	}
	
	public void localProgress(){
	
		print("change!");
		
		gm.trigger();
		
	}
	
	public void localGoodAchievement(){
		
		print("local good!");
		
		localAchievement.SetActive(true);
		
		gm.Set(200);
				
		
	}
	
	public void localSuperAchievement(){
		
		print("local super!");
	}
	
	void Update(){
	
		currentTime += Time.deltaTime;
		
		if(currentTime > timeout){
			localAchievement.SetActive(false);
			currentTime = 0;
		}
	
	
	}
}
