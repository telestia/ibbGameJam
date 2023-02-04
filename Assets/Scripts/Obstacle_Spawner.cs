using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private GameObject ground;
    private float[] arr;
	private float groundHeight;
	float[] even = {2, 4};


	// Use this for initialization
	void Start () {

        groundHeight = ground.GetComponent<Renderer>().bounds.size.y;
		
        arr = new float[] { -groundHeight / 3,
                groundHeight / 3,
                0 };
		// infinite coin spawning function, asynchronous
		StartCoroutine(SpawnObstacle());
	}


	IEnumerator SpawnObstacle() {

		while (true) {

			// number of coins we could spawn vertically
			int obstacleThisRow = Random.Range(1, 3);

			int oldValue = Random.Range(0,3);

			// instantiate all coins in this row separated by some random amount of space
			for (int i = 0; i < obstacleThisRow; i++) {
				
				Instantiate(prefab, new Vector3(10, arr[oldValue], -1), Quaternion.identity);
				oldValue = randomDifferentNumber(oldValue);
			}



			// pause 1-5 seconds until the next coin spawns
			yield return new WaitForSeconds(1);
		}
	}

	public int randomDifferentNumber(int number){
		int newNumber = Random.Range(0,3);
		if(newNumber == number){
			newNumber = randomDifferentNumber(number);
		}
	
		return newNumber;
	}
}
