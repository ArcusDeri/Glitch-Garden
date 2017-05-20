using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static void LoadLevel(string levelName){
		Debug.Log ("Load " + levelName + " scene");
		SceneManager.LoadScene (levelName);
	}
	public static void Quit(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
