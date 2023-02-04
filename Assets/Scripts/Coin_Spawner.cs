using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private GameObject ground;

	private float groundHeight;
    
    float[] nums = {2, 3, 4};
    int c = 0;

	// Use this for initialization
	void Start () {

        groundHeight = ground.GetComponent<Renderer>().bounds.size.y;
		

		// infinite coin spawning function, asynchronous
		StartCoroutine(SpawnCoin());
	}


	IEnumerator SpawnCoin()
    {

		while (true) {

			// number of coins we could spawn vertically
            if(c > 0)
            {
			int coinThisRow = Random.Range(1, 4);

			float oldValue = Random.Range(-2f, 2f);

			// instantiate all coins in this row separated by some random amount of space
			for (int i = 0; i < coinThisRow; i++) {
				Instantiate(prefab, new Vector3(10, (oldValue > 2f || oldValue < -2f) ? -100 : oldValue, -1), Quaternion.identity);
				oldValue = oldValue - transform.localScale.y * 2 / 3;
			}
            }
            c++;

			// pause 1-5 seconds until the next coin spawns
			yield return new WaitForSeconds(c > 1 ? nums[Random.Range(0,3)] : 2.5f);
		}
	}


}

