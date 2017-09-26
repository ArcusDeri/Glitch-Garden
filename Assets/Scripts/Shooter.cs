using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject Projectile, Gun;

	private GameObject ProjectileParent;
	private Animator MyAnimator;
	private Spawner LaneSpawner;

	void Start(){
		MyAnimator = GameObject.FindObjectOfType<Animator> ();
		SetMyLaneSpawner ();
		SetProjectileParent ();
	}

	void Update(){
		if (IsAttackerAheadInLane ()) {
			MyAnimator.SetBool ("isAttacking", true);
		} else {
			MyAnimator.SetBool ("isAttacking", false);
		}
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (Projectile) as GameObject;
		newProjectile.transform.parent = ProjectileParent.transform;
		newProjectile.transform.position = Gun.transform.position;
	}

	private bool IsAttackerAheadInLane(){
		if (LaneSpawner.transform.childCount <= 0) {
			return false;
		}

		foreach (Transform child in LaneSpawner.transform) {
			if (child.position.x > transform.position.x) {
				return true;
			}
		}
		//attackers behind tower
		return false;
	}

	private void SetMyLaneSpawner(){
		var spawnersParent = GameObject.Find ("Spawners");

		var spawners = spawnersParent.GetComponentsInChildren<Spawner>();
		foreach (Spawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				LaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in it's lane.");
	}

	private void SetProjectileParent(){
		ProjectileParent = GameObject.Find ("Projectiles");
		if (!ProjectileParent) {
			ProjectileParent = new GameObject ("Projectiles");
		}
	}
}
