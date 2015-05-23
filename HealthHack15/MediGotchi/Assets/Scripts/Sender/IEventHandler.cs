using UnityEngine;
using System.Collections;
using System;

public interface IEventHandler {

	void Publish(int points);
	
	event Action goodEvent;
	event Action superEvent;
	
	void SetUp(int eventThresholdGood,int eventThresholdSuper);
	
	
	
}
