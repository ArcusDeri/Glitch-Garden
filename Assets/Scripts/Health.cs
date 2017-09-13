using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float HealthPoints;

	public void DealDamage(float dmg){
		HealthPoints -= dmg;
		if (HealthPoints <= 0) {
			DestroyObject ();
		}
	}

	public void DestroyObject(){
		Destroy (gameObject);
	}
}
