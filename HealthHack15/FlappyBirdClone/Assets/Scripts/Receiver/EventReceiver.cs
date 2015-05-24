using UnityEngine;
using System.Collections;
using System;
using JsonFx.Json;

public class EventReceiver : MonoBehaviour, IEventReceiver {


	const string DOMAIN = "http://healthsdk.azurewebsites.net/getdataforuser/123"; 
		

	public void Poll(Action<HealthDTO[]> callback )
	{
		var www = new WWW(DOMAIN);
		StartCoroutine(receive(www,callback));
	}
	
	IEnumerator receive(WWW www, Action<HealthDTO[]> callback){
	
	
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			
            var reader = new JsonReader();

            var healthDtos = reader.Read<HealthDTO[]>(www.text);
			
			if(healthDtos.Length > 0)			
				callback(healthDtos);
		} else {
			Debug.Log("WWW Error: "+ www.error);
			
		}
	}
	


}
