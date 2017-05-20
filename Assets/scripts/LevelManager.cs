using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string levelName){
		Debug.Log ("Load level request");
		SceneManager.LoadScene (levelName);
	}

	void Start(){
		if(SceneManager.GetActiveScene().buildIndex == 0)
			Invoke ("LoadNextLevel",3.0f);
	}

	public void Quit(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
