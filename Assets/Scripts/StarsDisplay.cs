using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarsDisplay : MonoBehaviour {

	public enum TransactionStatus
	{
		SUCCESS,
		FAILURE
	}

	private Text TextShown;
	private int StarsBalance = 100;

	void Start(){
		TextShown = this.GetComponent<Text> ();
		UpdateBalance ();
	}

	public void AddStarsToDisplay(int amount){
		StarsBalance += amount;
		UpdateBalance ();
	}

	public TransactionStatus UseStars(int amount){
		if (StarsBalance >= amount) {
			StarsBalance -= amount;
			UpdateBalance ();
			return TransactionStatus.SUCCESS;
		}
		return TransactionStatus.FAILURE;
	}

	private void UpdateBalance(){
		TextShown.text = StarsBalance.ToString ();
	}
}
