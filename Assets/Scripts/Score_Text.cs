using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Text : MonoBehaviour
{
    [SerializeField] private GameObject textMesh;
    int totalCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalCoin = GetComponent<Player_Controller>().coinTotal;
        TMPro.TextMeshProUGUI tmp = textMesh.GetComponent<TMPro.TextMeshProUGUI>();
        
        tmp.text = "Score: " + totalCoin;
    }
}
