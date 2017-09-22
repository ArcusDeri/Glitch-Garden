using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] AttackersToSpawn;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update (){

		foreach (GameObject attacker in AttackersToSpawn) {
			if (IsTimeToSpawn (attacker)) {
				Spawn (attacker);
			}
		}
	}

	void Spawn(GameObject myObject){
		GameObject myAttacker = Instantiate (myObject) as GameObject;
		myAttacker.transform.parent = gameObject.transform;
		myAttacker.transform.position = gameObject.transform.position;
	}

	bool IsTimeToSpawn(GameObject myObject){
		Attacker attacker = myObject.GetComponent<Attacker> ();
		float spawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / spawnDelay;

		if (Time.deltaTime > spawnDelay) {
			Debug.LogWarning ("Spawn rate capped by framerate.");
		}

		float chanceToSpawnNow = spawnsPerSecond * Time.deltaTime / 5;

		if (Random.value < chanceToSpawnNow)
			return true;
		else
			return false;
	}
}
