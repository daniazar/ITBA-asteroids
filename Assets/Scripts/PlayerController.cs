using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float forwardThrust = 350;
	public float turnThrust = 400;
	public GameObject BulletPrefab;

	public GameObject ExplosionPrefab;

	public static int score = 0;
	public static int lives = 3;

	private float time =0;

	enum State
	{
		Playing,
		Explosion,
		Invinvible
	}

	private State state = State.Playing;
	public float shipInvisibleTime = 1.5f;
	public float blinkRate = 0.1f;
	public int numberOfTimesToBlink = 50;
	public int maxSpeed = 100;

	public float ShotDelay = 0.2f;
	private int blinkCount;
	private float thrust = 0f;
	private float turn = 0f;
	private Vector3 speed;
	
	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		time += Time.deltaTime;

		if (state != State.Explosion) {
			thrust = Input.GetAxis ("Vertical") * forwardThrust;
			turn = Input.GetAxis ("Horizontal") * turnThrust;
			
			if (thrust > 0f) {
				
				renderer.enabled = false;
				rigidbody.AddRelativeForce (Vector3.forward * thrust * Time.deltaTime);
				
				
			}
			
			rigidbody.AddRelativeTorque (Vector3.up * turn * Time.deltaTime);
	
			if (Input.GetKeyDown ("space") && time > ShotDelay) {
				//Fire bullet
				Instantiate (BulletPrefab, transform.position, transform.rotation);
				time = 0;
			}
	transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 360); 
	rigidbody.angularVelocity = new Vector3(0, rigidbody.angularVelocity.y, 0); 
	speed = rigidbody.velocity;
	if(speed.x > maxSpeed)
		speed.x = maxSpeed;
	if(speed.z > maxSpeed)
		speed.z = maxSpeed;

	if(speed.x < -maxSpeed)
		speed.x = -maxSpeed;
	if(speed.z < -maxSpeed)
		speed.z = -maxSpeed;
		
	speed.y = 0;
	rigidbody.velocity = speed;
		
			//transform.Translate(new Vector3(transform.position.x, 0 , transform.position.z));
		}
	}
	/*
	void OnDrawGizmos ()
	{
		
		Gizmos.color = new Color (1.0f, 0f, 0f);
		Gizmos.DrawLine (transform.position, transform.position + transform.forward * 10f);
	}
	 */
	
	void OnGUI ()
	{
		GUI.Label (new Rect (Screen.width / 2 - 20, 10, 120, 20), "Score: " + PlayerController.score.ToString ());
		GUI.Label (new Rect (Screen.width / 2 - 20, 30, 60, 20), "Lives: " + PlayerController.lives.ToString ());
		
	}

	void OnTriggerEnter (Collider otherObject)
	{
		//Debug.Log("Hit an " + otherObject.name);
		if (otherObject.tag == "Enemy" && state == PlayerController.State.Playing) {
			StartCoroutine (DestroyShip (otherObject.gameObject));
		}
	}

	IEnumerator DestroyShip (GameObject enemy)
	{
		state = State.Explosion;
		Instantiate (ExplosionPrefab, transform.position, transform.rotation);
		EnemyManager.DestroyEnemy (enemy);
		score -= 100;
		lives--;
		ToggleVisibility ();
		
		//gameObject.renderer.enabled = false;
		// mover si es necesario
		yield return new WaitForSeconds (shipInvisibleTime);
		if (lives > 0) {
			ToggleVisibility ();
			//	gameObject.renderer.enabled = true;
			state = State.Invinvible;
			blinkCount = 0;			
			while( blinkCount < numberOfTimesToBlink)
			{
				ToggleVisibility();
				blinkCount++;
				yield return new WaitForSeconds(blinkRate);
			}
			state = State.Playing;
		} else {
			Application.LoadLevel (2);
		}
	}

	void ToggleVisibility ()
	{
		// toggles the visibility of this gameobject and all it's children
		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer> ();
		foreach (Renderer re in renderers) {
			re.enabled = !re.enabled;
		}
	}
}
