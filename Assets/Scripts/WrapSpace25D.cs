using UnityEngine;
using System;

public class WrapSpace25D : MonoBehaviour{
	public int limits = 100;
	private GameObject player;
	private Vector3 otherpos; 
	private Transform trans;
	private Vector3 distance;
	// Use this for initialization
	void Start () {
			player = GameObject.Find("Player2.5D");
	otherpos = player.transform.position;	

	}
	private float min =0.0001f;
	// Update is called once per frame
	void Update () {
		Vector3 pos = gameObject.transform.position;
		otherpos = player.transform.position;
		distance = otherpos - pos;
		if (distance.z >= limits)
		{
			pos.z = otherpos.z + limits - min;
		}else if (distance.z<= -limits)
		{
			pos.z = otherpos.z - limits + min;
		} else if (distance.x >= limits)
		{
			pos.x = otherpos.x + limits - min;
		} else if (distance.x <= -limits)
		{
			pos.x = otherpos.x - limits + min;
		} 
		
		
		
		gameObject.transform.position = pos;
		
	
	}
}
