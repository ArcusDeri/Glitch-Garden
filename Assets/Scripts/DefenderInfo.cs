using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderInfo : MonoBehaviour {

	private Defenders SelectedDefender;
	private Text NamePool;
	private Text HealthPool;
	private Text DamagePool;
	private Text CostPool;
	private bool IsVisible = false;

	// Use this for initialization
	void Start () {
		if(Button.SelectedDefender)
			SelectedDefender = Button.SelectedDefender.GetComponent<Defenders>();
		gameObject.transform.localScale = new Vector3 (0, 0, 0);
		NamePool = GameObject.Find ("NamePool").GetComponent<Text>();
		HealthPool = GameObject.Find ("HealthPool").GetComponent<Text>();
		DamagePool = GameObject.Find ("DamagePool").GetComponent<Text>();
		CostPool = GameObject.Find ("CostPool").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateDefender(){
		SelectedDefender = Button.SelectedDefender.GetComponent<Defenders>();
		UpdateInfo ();
		if(!IsVisible)
			TurnVisible ();
	}

	void UpdateInfo(){
		NamePool.text = SelectedDefender.Name;
		HealthPool.text = SelectedDefender.GetComponent<Health> ().HealthPoints.ToString ();
		DamagePool.text = SelectedDefender.Damage;
		CostPool.text = SelectedDefender.StarCost.ToString ();
	}

	public void TurnVisible(){
		gameObject.transform.localScale = new Vector3 (1, 1, 0);
	}
}
