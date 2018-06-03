using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour {

    public GameObject[] Floor;    
    public Transform GenerationPoint;
    public float DistanceBetweenFloor;
    private float FloorWidth;
    private int FloorSelector;
    public bool TerrainLoop;

	// Use this for initialization
	void Start () {

        FloorWidth = 12;

	}
	
	// Update is called once per frame
	void Update () {

        

        if (transform.position.x < GenerationPoint.position.x && !TerrainLoop)
        {
            FloorSelector = Random.Range(0, 4);
            if(FloorSelector != 3)
            {
                transform.position = new Vector3(transform.position.x + FloorWidth + DistanceBetweenFloor, transform.position.y, 0);
                GameObject CurrentFloor = Instantiate(Floor[FloorSelector], transform.position, transform.rotation);
            }

            if(FloorSelector == 3)
            {
                transform.position = new Vector3(transform.position.x + FloorWidth + DistanceBetweenFloor, transform.position.y, 0);
                GameObject CurrentFloor = Instantiate(Floor[FloorSelector], transform.position + new Vector3 (0,0.3f,0) , transform.rotation);
            }
            
            
            
        }

        if (transform.position.x < GenerationPoint.position.x && TerrainLoop)
        {
            
            transform.position = new Vector3(transform.position.x + FloorWidth + 4, transform.position.y, 0);
            GameObject CurrentFloor = Instantiate(Floor[4], transform.position, transform.rotation);


        }


    }

}
