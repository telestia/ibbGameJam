using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject background;
    private float backgroundWidth;
    private float backgroundHeight;
    private float backgroundMinY;
    private float backgroundMaxY;
    private float backgroundMinX;
    private float backgroundMaxX;
    private float playerWidth;
    private float playerHeight;
    private float moveVertical;
    private float moveHorizontal;
    private float y;
    private float x;
    public int coinTotal;
    public int bulletCount = 0;
    private int bulletCounter = 0; 
    [SerializeField] public float moveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 7f;
        playerWidth = GetComponent<Renderer>().bounds.size.y;
        playerHeight = GetComponent<Renderer>().bounds.size.x;
        backgroundMinY = background.GetComponent<GroundScript>().GetMinYPoint();
        backgroundMaxY = background.GetComponent<GroundScript>().GetMaxYPoint();
        backgroundMinX = background.GetComponent<GroundScript>().GetMinXPoint();
        backgroundMaxX = background.GetComponent<GroundScript>().GetMaxXPoint();
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


        Debug.Log(backgroundMinY);
        if((y < (backgroundMinY + playerWidth / 2) || y >  (backgroundMaxY - playerWidth / 2)))
        {
            y = transform.position.y;
        }
        if(!(x < (backgroundHeight / 2 - playerHeight / 2 - 0.3) && x > -(backgroundHeight / 2 - playerHeight / 2 - 0.3)))
        {
            x = transform.position.x;
        }

        transform.position = new Vector3(x, y, transform.position.z);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void PickupCollectable(int points)
    {
		coinTotal += points;
        bulletCounter++;
        if(bulletCounter == 5)
        {
            bulletCount++;
            bulletCounter = 0;
        }
	}
    private void OnTriggerEnter2D(Collider2D other) {
 
        if(other.tag == "Coin")
        {
            PickupCollectable(1);  
            Destroy(other.gameObject);
        }else if(other.tag == "Obstacle")
        {
            Die();
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        
    }
}
