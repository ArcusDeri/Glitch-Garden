using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfterSeconds;

	public void LoadLevel(string levelName){
		Debug.Log ("Load level request");
		SceneManager.LoadScene (levelName);
	}

	void Start(){
		if (autoLoadNextLevelAfterSeconds <= 0) {
			Debug.Log ("Autoload disabled");
		}else{
			Invoke ("LoadNextLevel",autoLoadNextLevelAfterSeconds);
		}
	}

	public void Quit(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
