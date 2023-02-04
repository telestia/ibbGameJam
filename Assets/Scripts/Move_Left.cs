using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Left : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // despawn object if it goes past the left edge of the screen
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

        else
        {
            // scroll based on SkyscraperSpawner static variable, speed
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        }
    }
}
