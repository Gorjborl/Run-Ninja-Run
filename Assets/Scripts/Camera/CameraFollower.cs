using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform Player;
    
    private float CameraOffset = 3.77f;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(Player.position.x + CameraOffset, transform.position.y, transform.position.z);
		
	}
}
