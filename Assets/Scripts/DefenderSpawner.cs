using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject DefenderParent;
	private StarsDisplay StarBalance;

	// Use this for initialization
	void Start () {
		DefenderParent = GameObject.Find ("Defenders");
		StarBalance = GameObject.FindObjectOfType<StarsDisplay> ();

		if (!DefenderParent) {
			DefenderParent = new GameObject ("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (IsAffordable ()) {
			SpawnDefender ();
		}
	}

	private bool IsAffordable(){
		var price = Button.SelectedDefender.GetComponent<Defenders> ().StarCost;
		var canAffordDefender = StarBalance.UseStars (price);
		if (canAffordDefender == StarsDisplay.TransactionStatus.SUCCESS) {
			return true;
		} else {
			Debug.Log ("Insufficient funds.");
			return false;
		}
	}

	private void SpawnDefender(){
		var pos = SnapToGrid (CalculateWorldPointOfClick ());
		GameObject newDefender = Instantiate (Button.SelectedDefender, pos, Quaternion.identity);
		newDefender.transform.SetParent (DefenderParent.transform);
	}

	Vector2 CalculateWorldPointOfClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f; //actually it doesn't matter in 2D mode with ortographic camera

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPos){
		var newX = Mathf.RoundToInt(rawWorldPos.x);
		var newY = Mathf.RoundToInt(rawWorldPos.y);

		return new Vector2 (newX, newY);
	}
}
