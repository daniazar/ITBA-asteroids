using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public int MaxEnemys = 5;
	public int EnemyChildNumber = 2;
	public int LimitToRegenerateEnemys = 4;
	public GameObject smallRock;
	public GameObject bigRock;
	public GameObject ExplosionPrefab;
	
	public static GameObject smallRocks;
	public static int EnemyChildNumbers;	
	public static int maximumScore = 5000;
	public static GameObject ExplosionPrefabStatic;
	
	
	public static int enemyCount;

	// Use this for initialization
	void Start () 
	{
		enemyCount = MaxEnemys;		
		EnemyChildNumbers = EnemyChildNumber;
		smallRocks = smallRock;
		ExplosionPrefabStatic = ExplosionPrefab;
	}
	
	void FixedUpdate () {
		if (enemyCount < LimitToRegenerateEnemys && enemyCount < MaxEnemys) {
			enemyCount++;
			Instantiate(bigRock, randomPosition(), transform.rotation);
		}
	}
	
	private Vector3 randomPosition() {
		//return new Vector3(Random.Range(MySpace.north, MySpace.south), 0f, 
		 //                  Random.Range(MySpace.east, MySpace.west));
		return new Vector3(-MySpace.east, 0f, MySpace.west);
	
	}
	
	public static void DestroyEnemy(GameObject enemy)
	{
	
		enemyCount--;	
		PlayerController.score += 100;
		Instantiate(ExplosionPrefabStatic, enemy.transform.position, enemy.transform.rotation);
		Destroy(enemy);
		
		if(	PlayerController.score > maximumScore)
			Application.LoadLevel(3);
	}
	
	
	public static void CreateEnemyChild(Vector3 positionParent, Quaternion rotationParent)
	{
		Vector3 oldPos = positionParent;
		
		for (int i = 0; i < EnemyChildNumbers; i++)
		{
			enemyCount++;
			oldPos.x += Random.Range(-2, 2);
			oldPos.z += Random.Range(-2, 2);
			Instantiate(smallRocks, oldPos, rotationParent);
		}
		
	}
	
}
