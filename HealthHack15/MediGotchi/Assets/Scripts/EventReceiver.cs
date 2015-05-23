using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System;

public class EventReceiver : MonoBehaviour, IEventReceiver {


	const string DOMAIN = "http://healthsdk.azurewebsites.net/getdataforuser/1"; 

	public void Poll(Action<HealthDTO> callback )
	{
	
		var www = new WWW(DOMAIN);
		
		StartCoroutine(receive(www,callback));
		
		
	}
	
	IEnumerator receive(WWW www, Action<HealthDTO> callback){
	
	
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.data);
			
			var healthDTO  = JsonConvert.DeserializeObject<HealthDTO>(www.data);
			
			callback(healthDTO);
		} else {
			Debug.Log("WWW Error: "+ www.error);
			
		}
	}
	


}
