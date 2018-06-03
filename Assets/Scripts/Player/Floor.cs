using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    private Transform CameraPosition;

	// Use this for initialization
	void Start () {

        CameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform;
        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.x <= CameraPosition.position.x - 20)
        {
            Destroy(gameObject);
        }
     

	}
}
