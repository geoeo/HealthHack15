using UnityEngine;
using System.Collections;
using System;

public class InputAccelerometer : MonoBehaviour {

	float x_old;
	float y_old;
	float z_old;
	
	bool hasChanged;
	public int counter;

	// Use this for initialization
	void Start () {
	
		x_old = 0;
		y_old = 0;
		z_old = 0;
		
		counter = 0;
		
		hasChanged = false;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		var x_new = Input.acceleration.x;
		var y_new = Input.acceleration.y;
		var z_new = Input.acceleration.z;
		
		double old_value = x_old*x_new + y_old*y_new + z_old*z_new;
		double old_value_sqrt = Math.Abs(Math.Sqrt((double)(x_old*x_old + y_old*y_old + z_old*z_old)));
		double new_value_sqrt = Math.Abs(Math.Sqrt((double)(x_new*x_new + y_new*y_new + z_new*z_new)));
		
		old_value /= old_value_sqrt * new_value_sqrt;
		
		if((old_value > 0.992) &&(old_value <= 0.994))
		{
			if(!hasChanged){
				hasChanged = true;
				counter++;
			}
			else {
				hasChanged = false;
			}
		}
		
		x_old = x_new;
		y_old = y_new;
		z_old = z_new;
		
	}
}
