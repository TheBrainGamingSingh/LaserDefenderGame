using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	float width = 8f;
	float height = 12f;
	float speed = 3f;
	float xmin = -4f;
	float xmax = 4f;
	bool GoingRight = true;
	// Use this for initialization
	void Start () {
		SpawnUntilFull ();
	}
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3(width,height));
	}
	// Update is called once per frame
	void Update () {
		if(GoingRight)
			transform.position += Vector3.right * speed * Time.deltaTime;
		else
			transform.position += Vector3.left * speed * Time.deltaTime;
		if (transform.position.x < xmin)
			GoingRight = true;
		if (transform.position.x > xmax)
			GoingRight = false;
		if (AllEnemiesDead()) {
			SpawnUntilFull ();
		}
	}
	Transform NextFreePosition(){
		foreach (Transform childobject in transform)
			if (childobject.childCount == 0)
				return childobject;
		return null;
	}

	bool AllEnemiesDead(){
		foreach (Transform childobject in transform)
			if (childobject.childCount > 0)
				return false;
		return true;
	}

	void Respawn(){
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position , Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull(){
		Transform FreePosition = NextFreePosition ();

		if (FreePosition) {
			GameObject enemy = Instantiate (enemyPrefab, FreePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = FreePosition;
		}

		if(NextFreePosition())
			Invoke ("SpawnUntilFull",0.5f);
	}
}
