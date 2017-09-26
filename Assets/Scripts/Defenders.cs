using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {

	private StarsDisplay StarsDisplay;

	void Start(){
		StarsDisplay = GameObject.FindObjectOfType<StarsDisplay> ();
	}

	public void AddStars(int amount){
		StarsDisplay.AddStarsToDisplay (amount);
	}
}
