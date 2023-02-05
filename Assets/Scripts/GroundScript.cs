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
        height = GetComponent<Renderer>().bounds.size.y;
        centerX = GetComponent<Renderer>().bounds.center.x;
        width = GetComponent<Renderer>().bounds.size.x;

    }

    public float GetMinYPoint()
    {
        return centerY - height / 2;
    }
    public float GetMaxYPoint()
    {
        return centerY + height / 2;
    }

    public float GetMinXPoint()
    {
        return centerX - width / 2;
    }
    public float GetMaxXPoint()
    {
        return centerY + width / 2;
    }
}
