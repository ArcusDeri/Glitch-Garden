using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {

	public int StarCost = 100;//default value

	private StarsDisplay StarsDisplay;

	void Start(){
		StarsDisplay = GameObject.FindObjectOfType<StarsDisplay> ();
	}

	public void AddStars(int amount){
		StarsDisplay.AddStarsToDisplay (amount);
	}
}
