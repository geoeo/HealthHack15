using UnityEngine;
using System.Collections;
using System;

public class Poller : MonoBehaviour {

	IEventReceiver eventReceiver;
	
	public event Action goodEvent;
	
	public event Action superEvent;
	
	float timeout = 2;
	float currentTime = 0;

	// Use this for initialization
	void Start () {
		
		eventReceiver = this.gameObject.AddComponent<EventReceiver>();
	}
	
	void processDataCallBack(HealthDTO[] polledDTOs){
	
		foreach(HealthDTO dto in polledDTOs){	
	
			var receivedEvent = dto.EventId;
			
			switch(receivedEvent){
				
			case "1":
				if(goodEvent != null)
					goodEvent();
				
				break;
			case "2":
				if(superEvent != null)
					superEvent();
				
				break;
			}
		
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		currentTime += Time.deltaTime;
		
		if(currentTime >= timeout){
			eventReceiver.Poll(processDataCallBack);
			
			currentTime = 0;
		}
		
		
//		if(polledDTO != null){
//			var receivedEvent = polledDTO.getEvent();
//			
//			switch(receivedEvent){
//				
//			case "1":
//				if(goodEvent != null)
//					goodEvent();
//				
//				break;
//			case "2":
//				if(superEvent != null)
//					superEvent();
//				
//				break;
//			}
//			
//		}
				
			
			
	
		
		
		// Debug
//		foreach(string app in DebugDTO.app_id)
//			print (app + " " + DebugDTO.event_id);
			
			
		
	
	}
}
