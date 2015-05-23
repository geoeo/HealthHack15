using UnityEngine;
using System.Collections;

public class EventHandler : IEventHandler {

	int eventThresholdGood;
	int eventThresholdSuper; 

	GameObject senderGO;
	
	bool hasSentGood;
	bool hasSentSuper;
	
	public EventHandler(int good, int super){
	
		eventThresholdGood = good;
		eventThresholdSuper = super;
		
		senderGO = new GameObject();
		senderGO.AddComponent(typeof(Sender));
		
		
		hasSentGood = false;
		hasSentSuper = false;
	
	}
	
	
	public void Publish(int points)
	{
		if(points >= eventThresholdGood && !hasSentGood)
		{
			var sender = senderGO.GetComponent(typeof(Sender)) as ISender;
			sender.PublishGoodEvent();
			hasSentGood = true;
		}
			
		
		if(points >= eventThresholdSuper && !hasSentSuper)
		{
			var sender = senderGO.GetComponent(typeof(Sender)) as ISender;
			sender.PublishSuperEvent();
			hasSentSuper= true;
		}
	}


}
