using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarsDisplay : MonoBehaviour {

	private Text TextShown;
	private int StarsBalance = 0;

	void Start(){
		TextShown = this.GetComponent<Text> ();
		UpdateBalance ();
	}

	public void AddStarsToDisplay(int amount){
		StarsBalance += amount;
		UpdateBalance ();
	}

	public void UseStars(int amount){
		StarsBalance -= amount;
		UpdateBalance ();
	}

	private void UpdateBalance(){
		TextShown.text = StarsBalance.ToString ();
	}
}
