using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
	}
	void Awake(){
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Dont destroy onLoad: " + name);
	}
	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelLoad;
	}
	void OnLevelLoad(Scene scene, LoadSceneMode mode){
		AudioClip thisLevelMusic = levelMusicChangeArray [scene.buildIndex];
		audioSource = GetComponent<AudioSource> ();

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = scene.buildIndex > 0 ? true : false;
			audioSource.Play ();
		}
	}
	public void ChangeVolume(float val){
		audioSource.volume = val;
	}
}
