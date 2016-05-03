using UnityEngine;
using System.Collections;

public class WrapSpace : MonoBehaviour{
	
	// Use this for initialization
	void Start () {
	
	}
	private float min =0.0001f;
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = gameObject.transform.position;
		if (pos.z >= MySpace.north)
		{
			pos.z = MySpace.south + min;
		} else if (pos.z <= MySpace.south)
		{
			pos.z = MySpace.north - min;
		} else if (pos.x >= MySpace.east)
		{
			pos.x = MySpace.west + min;
		} else if (pos.x <= MySpace.west)
		{
			pos.x = MySpace.east - min;
		}
		
		
		
		gameObject.transform.position = pos;
		
	
	}
}
