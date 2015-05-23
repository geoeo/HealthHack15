using UnityEngine;
using System.Collections;
using System;

public class EventHandler : IEventHandler {

	public event Action goodEvent;
	public event Action superEvent;

	int eventThresholdGood;
	int eventThresholdSuper; 

	GameObject senderGO;
	
	bool hasSentGood;
	bool hasSentSuper;
	
	public void SetUp(int good,int super){
	
		senderGO = new GameObject("Sender");
		senderGO.AddComponent(typeof(Sender));
		
		
		hasSentGood = false;
		hasSentSuper = false;
	
		eventThresholdGood = good;
		eventThresholdSuper = super;
	
	}
	
	
	public void Publish(int points)
	{
		if(points >= eventThresholdGood && !hasSentGood)
		{
			if(goodEvent != null)
				goodEvent();
			
			var sender = senderGO.GetComponent(typeof(Sender)) as ISender;
			sender.PublishGoodEvent();
			hasSentGood = true;

		}
			
		
		if(points >= eventThresholdSuper && !hasSentSuper)
		{
			if(superEvent != null)
				superEvent();
		
			var sender = senderGO.GetComponent(typeof(Sender)) as ISender;
			sender.PublishSuperEvent();
			hasSentSuper= true;
		}
	}


}
