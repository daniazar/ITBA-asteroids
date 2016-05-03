using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	private GameObject player;
	private Rigidbody body;
	public float speed;
	// Use this for initialization
	void Start () {
		
	player = GameObject.Find("player");
	body = player.GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	GetComponent<Renderer>().material.mainTextureOffset += new Vector2( -body.velocity.x * speed, - body.velocity.z * speed);
   
	}
}
