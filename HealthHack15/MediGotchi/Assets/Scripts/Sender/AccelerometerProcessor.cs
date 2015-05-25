using UnityEngine;
using System.Collections;

public class AccelerometerProcessor : MonoBehaviour {

	public GameObject eventSource;
	
	public GameObject localEvent;
	
	public GameObject localAchievement;
	
	public Animator animator;
	
	float currentTime_ui = 0;
	float currentTime_anim = 0;
	
	float ui_timeout = 25;
	
	float animator_timeout = 2;
	
	GameManager gm;


	// Use this for initialization
	void Start () {
	
		var scraper = eventSource.GetComponent<InputAccelerometer>();
		scraper.changeEvent += localProgress;
		scraper.noChangeEvent += triggerAction;
		
		scraper.eventHandler.goodEvent += localGoodAchievement;
		scraper.eventHandler.superEvent += localSuperAchievement;
		
		gm = localEvent.GetComponent<GameManager>();
	}
	
	public void localProgress(){
	
		print("change!");
		
		gm.trigger();
		
		if(!animator.GetBool("moving"));
			animator.SetBool("moving",true);
		
	}
	
	public void localGoodAchievement(){
	
		animator.SetBool("moving",false);
		animator.SetBool ("happy",true);
		
		print("local good!");
		
		localAchievement.SetActive(true);
		
		gm.Set(200);
				
		
	}
	
	public void localSuperAchievement(){
		
		print("local super!");
	}
	
	public void triggerAction(){
		animator.SetTrigger("action");
	}
	
	void Update(){
	
		
	
		currentTime_ui += Time.deltaTime;
		currentTime_anim += Time.deltaTime;
		
		if(currentTime_ui > ui_timeout){
			localAchievement.SetActive(false);
			currentTime_ui = 0;
		}
		
		if(currentTime_anim > animator_timeout && animator.GetBool("moving")){
			animator.SetBool("moving",false);
			currentTime_anim = 0;
		}
	
	
	}
}
