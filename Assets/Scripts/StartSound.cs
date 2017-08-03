using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour {

	private MusicManager musicMngr;
	// Use this for initialization
	void Start () 
	{
		musicMngr = GameObject.FindObjectOfType<MusicManager> ();
		if (musicMngr) {
			float volumeLevel = PlayerPrefsManager.GetMasterVolume ();
			musicMngr.ChangeVolume (volumeLevel);
		} else {
			Debug.LogWarning ("No music manager found, can't set volume.");
		}
	}
}
