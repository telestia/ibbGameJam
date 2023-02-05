using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Scroller : MonoBehaviour
{
    [Range(-1f, 5f)]
    public float scrollSpeed = 1f;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //mat.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0f);
        offset += (Time.deltaTime * scrollSpeed) / 10f;

        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
