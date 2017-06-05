using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f)
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		else
			Debug.LogError ("Error: Master volume out of range");
	}
	public static void SetDifficulty(float diffLvl){
		if (diffLvl >= 0f && diffLvl <= 3f)
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, diffLvl);
		else
			Debug.LogError ("Error: difficulty out of range");
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}

	public static void UnlockLevel(int level){
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (),1);//1 for true
		} else {
			Debug.LogError ("Error: tried to unlock level not in Build settings");
		}	
	}

	public static bool IsLevelUnlocked(int level){
		int level_value = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isUnlocked = (level_value == 1);

		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			return isUnlocked;
		} else {
			Debug.LogError ("Error: level not in build order");
			return false;	
		}
	}
}
