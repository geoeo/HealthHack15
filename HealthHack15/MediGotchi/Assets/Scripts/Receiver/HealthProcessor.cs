using UnityEngine;
using System.Collections;
using System;

public class HealthProcessor : MonoBehaviour {

	public GameObject eventSource;

	// Use this for initialization
	void Start () {
	
		var receiver = eventSource.GetComponent<Poller>();
		
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
