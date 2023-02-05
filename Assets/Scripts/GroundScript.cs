using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private float centerY;
    private float centerX;
    private float width;
    private float height;
    
    // Start is called before the first frame update
    void Start()
    {
        centerY = GetComponent<Renderer>().bounds.center.y;
        width = GetComponent<Renderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public float GetMinYPoint()
    {
        return centerY - width / 2;
    }
    public float GetMaxYPoint()
    {
        return centerY + width / 2;
    }

    public float GetMinXPoint()
    {
        return centerX - height / 2;
    }
    public float GetMaxXPoint()
    {
        return centerY + height / 2;
    }
}
