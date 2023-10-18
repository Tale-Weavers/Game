using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolBall : MonoBehaviour
{
    public Square tile;
    public bool beingPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
