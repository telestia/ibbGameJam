using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Spawner : MonoBehaviour
{
public GameObject prefab;
    [SerializeField] private GameObject ground;

	private float groundHeight;

	// Use this for initialization
	void Start () {

        groundHeight = ground.GetComponent<Renderer>().bounds.size.y;
		

		// infinite coin spawning function, asynchronous
		StartCoroutine(SpawnObstacle());
	}


	IEnumerator SpawnObstacle() {

		while (true) {

			// number of coins we could spawn vertically
			int coinThisRow = Random.Range(1, 4);

			float oldValue = Random.Range(-2f ,2f);

			// instantiate all coins in this row separated by some random amount of space
			for (int i = 0; i < coinThisRow; i++) {
				
				Instantiate(prefab, new Vector3(10, oldValue, -1), Quaternion.identity);
				oldValue = oldValue - transform.localScale.y * 4 / 3;
			}



			// pause 1-5 seconds until the next coin spawns
			yield return new WaitForSeconds(Random.Range(1, 5));
		}
	}


}
