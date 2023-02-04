using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject background;
    private float backgroundWidth;
    private float backgroundHeight;
    private float playerWidth;
    private float playerHeight;
    private float moveVertical;
    private float moveHorizontal;
    private float y;
    private float x;
    [SerializeField] public float moveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 7f;
        playerWidth = GetComponent<Renderer>().bounds.size.y;
        playerHeight = GetComponent<Renderer>().bounds.size.x;
        backgroundWidth = background.GetComponent<Renderer>().bounds.size.y;
        backgroundHeight = background.GetComponent<Renderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");
        moveHorizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {

        y = moveSpeed * moveVertical * Time.deltaTime + transform.position.y;
        x = moveSpeed * moveHorizontal * Time.deltaTime + transform.position.x;

 
        if(!(y < (backgroundWidth / 2 - playerWidth / 2) && y > -(backgroundWidth / 2 - playerWidth / 2)))
        {
            y = transform.position.y;
        }
        if(!(x < (backgroundHeight / 2 - playerHeight / 2 - 0.3) && x > -(backgroundHeight / 2 - playerHeight / 2 - 0.3)))
        {
            x = transform.position.x;
        }

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
