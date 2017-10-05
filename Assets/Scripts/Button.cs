using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	private Button[] ButtonArray;
	private SpriteRenderer Renderer;

	public GameObject DefenderPrefab;
	public static GameObject SelectedDefender;

	void Start (){
		Renderer = GetComponent<SpriteRenderer> ();
		ButtonArray = GameObject.FindObjectsOfType<Button> ();
	}

	void OnMouseDown(){
		ToggleButtonsColor ();
		SetSelectedDefender();
		DefenderInfoUpdate ();
	}

	private void ToggleButtonsColor(){

		foreach (Button thisBtn in ButtonArray) {
			thisBtn.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		Renderer.color = Color.white;
	}

	private void SetSelectedDefender(){
		SelectedDefender = DefenderPrefab;
	}

	private void DefenderInfoUpdate(){
		var info = GameObject.FindObjectOfType<DefenderInfo> ();
		info.UpdateDefender ();
	}
}
