using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParallax : MonoBehaviour {

    private float VelocityOffset = 0.01f;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.deltaTime * -VelocityOffset, 0);


    }
}
