using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float forwardThrust = 150;
    public float turnThrust = 100F;
	
	// Update is called once per frame
	void Start () {
		
		float x = Random.Range(-10, 10);
		float z = Random.Range(-10, 10);
		while(x == 0)
		{
			x = Random.Range(-10, 10);

		}
		
		while(z == 0)
		{
			z = Random.Range(-10, 10);

		}

		rigidbody.velocity = new Vector3(x , 0, z);
	//	rigidbody.AddTorque(new Vector3( Random.Range(-10, 10), 5, Random.Range(-10, 10)));
		rigidbody.angularVelocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)); 

	}
	
	void OnTriggerEnter(Collider otherObject)
	{
		
		
		//EnemyManager em = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<EnemyManager>();
		if (otherObject.tag == "Bullet")
		{
			Destroy(otherObject.gameObject);
			EnemyManager.CreateEnemyChild(otherObject.gameObject.transform.position, otherObject.gameObject.transform.rotation);
			EnemyManager.DestroyEnemy(gameObject);
		}
	}

}
