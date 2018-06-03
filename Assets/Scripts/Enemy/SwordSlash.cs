using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : MonoBehaviour {

    private GameObject SwordSlashh;

    // Use this for initialization
    void Start()
    {

        SwordSlashh = gameObject.GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(-0.2f, 0, 0);
        transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);

        if (transform.localScale.x <= 0 && transform.localScale.y <= 0 && transform.localScale.z <= 0)
        {
            Destroy(gameObject);
        }


    }
}
