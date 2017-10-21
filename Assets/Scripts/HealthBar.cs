using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	private Slider MySlider;
	private Health MyHealth;
	private float MaxHealthPoints;

	// Use this for initialization
	void Start () {
		MySlider = gameObject.GetComponent<Slider> ();
		MyHealth = gameObject.GetComponentInParent<Health> ();
		MaxHealthPoints = MyHealth.HealthPoints;
	}

	// Update is called once per frame
	void Update () {
		MySlider.value = MyHealth.HealthPoints / MaxHealthPoints;
	}
}
