using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float lifetime = 1;	// 1 second
	
	
	Vector3 vel = new Vector3( 0, 0 , 1);
	
	void Start () {
		Destroy(gameObject, lifetime);	
	}

 	void FixedUpdate () {
		transform.Translate(vel);
	}
	
}
