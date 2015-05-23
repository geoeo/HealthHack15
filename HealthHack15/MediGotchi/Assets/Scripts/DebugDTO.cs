using UnityEngine;
using System.Collections;

public static class DebugDTO {

	public static string event_id = string.Empty;
	public static string[] app_id = new string[0];
	
	
	public static string[] GetAppIds(){
		return app_id;
	}
	
	public static string getEvent(){
		return event_id;
	}
}
