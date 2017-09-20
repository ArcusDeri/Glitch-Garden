using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float Speed;
	public float Damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		var target = collider.gameObject;

		if (target.GetComponent<Attacker> ()) {
			target.GetComponent<Health> ().DealDamage (Damage);
			Destroy (gameObject);
		}
	}
}
