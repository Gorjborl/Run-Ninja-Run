using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsParallax : MonoBehaviour {

    private float VelocityOffset = 0.08f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * VelocityOffset, 0);

    }
}
