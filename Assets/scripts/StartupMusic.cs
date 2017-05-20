using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupMusic : MonoBehaviour {
	public AudioSource startUpSound;

	// Use this for initialization
	void Start () {
		startUpSound.Play ();
		StartCoroutine (ExecuteAfterTime (3));
	}
	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		LevelManager.LoadLevel ("01 MainMenu");
	}
}