using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public int ThisLevelTime;

	private Slider MySlider;
	private LevelManager MyLevelManager;
	private AudioSource MyAudioSource;
	private Text CompletedMessage;

	// Use this for initialization
	void Start () {
		Setup ();	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateSlider ();
	}

	void Setup(){
		MyLevelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		CompletedMessage = GameObject.Find ("LevelCompleteMessage").GetComponent<Text> ();
		CompletedMessage.enabled = false;
		MyAudioSource = GameObject.Find ("MySource").GetComponent<AudioSource> ();

		var slider = GameObject.Find ("SliderTime");
		MySlider = slider.GetComponent<Slider> ();
	}

	void UpdateSlider(){
		MySlider.value = Time.timeSinceLevelLoad / ThisLevelTime;
		if (MySlider.value == 1f)
			EndLevel ();
	}

	void EndLevel(){
		CancelInvoke ("UpdateSlider");
		MyAudioSource.Play ();
		CompletedMessage.enabled = true;
		Invoke ("LoadNextLevel", MyAudioSource.clip.length);
	}

	void LoadNextLevel(){
		MyLevelManager.LoadNextLevel ();
	}
}
