using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private GameObject background;
    private int backgroundHalfOfHeight;
    private float speed = 2f;
    private float y;
    void Start()
    {
        backgroundHalfOfHeight = (int)(background.GetComponent<Renderer>().bounds.size.y / 2f);
    }

    void Update()
    {
        
        y = Mathf.Sin(Time.time * speed) * backgroundHalfOfHeight ;
        
      

        transform.position = new Vector3(transform.position.x, y + background.GetComponent<Renderer>().bounds.center.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Bullet")
        {
            
        }
    }
}
