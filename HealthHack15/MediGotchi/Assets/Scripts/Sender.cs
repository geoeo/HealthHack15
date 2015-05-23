using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sender : MonoBehaviour, ISender {

	
	const string DOMAIN = "http://healthsdk.azurewebsites.net/submitdata"; 
	

	public void PublishGoodEvent()
	{
		var json_string_1 = "{ UserId:123, ApplicationId:234, EventId:1 }";
		
		var encoding = new System.Text.UTF8Encoding();
		var postHeader = new Dictionary<string,string>();
		
		postHeader.Add("Content-Type", "text/json");
		postHeader.Add("Content-Length", json_string_1.Length.ToString());
		
		var www = new WWW(DOMAIN,encoding.GetBytes(json_string_1),postHeader);
		
		StartCoroutine(send(www));
	}
	
	public void PublishSuperEvent()
	{
		var json_string_2 = "{ UserId:123, ApplicationId:234, EventId:2 }";
		
		var encoding = new System.Text.UTF8Encoding();
		var postHeader = new Dictionary<string,string>();
		
		postHeader.Add("Content-Type", "text/json");
		postHeader.Add("Content-Length", json_string_2.Length.ToString());
		
		var www = new WWW(DOMAIN,encoding.GetBytes(json_string_2),postHeader);
		
		StartCoroutine(send(www));
	}
	
	IEnumerator send(WWW www){
	
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.data);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}  
		
		
	}
}
