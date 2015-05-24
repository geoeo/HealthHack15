using UnityEngine;
using System.Collections;
using System;

public class HealthProcessor : MonoBehaviour {

	public GameObject eventSource;
	
	public FlappyScript Flappy;
	public GameObject Booster;
	
	float mStartSpeed;
	Animator mAnimator;

	// Use this for initialization
	void Start () {
	
		var receiver = eventSource.GetComponent<Poller>();
		
		receiver.goodEvent += GoodEvent;	
		receiver.superEvent += SuperEvent;
		
		mStartSpeed = Flappy.XSpeed;
		mAnimator = Flappy.GetComponent<Animator>();
			
	
	}
	
	public void GoodEvent(){
	
		print ("GoodEvent");
		
		Flappy.XSpeed = mStartSpeed * 1.5f;
		mAnimator.SetBool("super", true);
		var booster = Instantiate(Booster, Flappy.transform.position, Quaternion.identity) as GameObject;
		booster.transform.parent = Flappy.transform;
		
	
	}
	
	public void SuperEvent(){
	
		print ("SuperEvent");
		
	}
	

}
