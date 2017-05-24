using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

	public float fadeOutTime;

	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();
		currentColor.a = 0;

		InvokeRepeating ("fadeOut", 1f, 0.009f);
	}

	// Update is called once per frame
	void Update () {
		
	}
	void fadeOut(){
		if (Time.timeSinceLevelLoad < fadeOutTime) {
			float alphaChange = Time.deltaTime / fadeOutTime;
			currentColor.a += alphaChange;
			fadePanel.color = currentColor;
		}
	}
}
