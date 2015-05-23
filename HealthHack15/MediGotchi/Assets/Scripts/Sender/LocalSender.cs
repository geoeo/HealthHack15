using UnityEngine;
using System.Collections;

public class LocalSender :MonoBehaviour, ISender {

	public void PublishGoodEvent()
	{
		DebugDTO.app_id = new string[]{"my_app"};
		DebugDTO.event_id = "good";
		
	}
	
	
	public void PublishSuperEvent(){
	
		DebugDTO.app_id = new string[]{"my_app"};
		DebugDTO.event_id = "super";
		
	}
}
