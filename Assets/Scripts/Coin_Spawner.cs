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
	private float groundMax;
	private float groundMin;

	// Use this for initialization
	void Start () {
        groundMax = ground.GetComponent<GroundScript>().GetMaxYPoint();
		groundMin = ground.GetComponent<GroundScript>().GetMinYPoint();
		

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

			float oldValue = Random.Range(groundMin, groundMax);

			// instantiate all coins in this row separated by some random amount of space
			for (int i = 0; i < coinThisRow; i++) {
				Instantiate(prefab, new Vector3(10, (oldValue > groundMax || oldValue < groundMin + 0.3) ? -100 : oldValue, -1), Quaternion.identity);
				oldValue = oldValue - transform.localScale.y * 2 / 3;
			}
            }
            c++;

			// pause 1-5 seconds until the next coin spawns
			yield return new WaitForSeconds(c > 1 ? nums[Random.Range(0,3)] : 2.5f);
		}
	}


}

