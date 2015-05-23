using UnityEngine;
using System.Collections;
using System;

public interface IEventReceiver {

	void Poll(Action<HealthDTO> callback);
	
}
