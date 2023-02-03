using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject ground;
    private float moveVertical;
    private float y;
    [SerializeField] public float moveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 7f;
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {

        if(moveVertical > 0f || moveVertical < 0f ) 
        {
            y = moveSpeed * moveVertical * Time.deltaTime + transform.position.y;
            
            if(y > (ground.transform.position.y - ground.transform.localScale.y / 2f + transform.localScale.y / 2) 
            && y < ground.transform.position.y + ground.transform.localScale.y / 2f - transform.localScale.y / 2  )
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

    }
}
