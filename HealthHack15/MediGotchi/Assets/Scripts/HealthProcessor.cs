using UnityEngine;
using System.Collections;
using System;

public class HealthProcessor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		var obj = new GameObject("HealthSDKProcessor");
		var receiver = obj.AddComponent<Poller>();
		
		receiver.goodEvent += GoodEvent;	
		receiver.superEvent += SuperEvent;
		
		
	
	}
	
	public void GoodEvent(){
	
		print ("GoodEvent");
		
	
	}
	
	public void SuperEvent(){
	
		print ("SuperEvent");
		
	}
	

}
