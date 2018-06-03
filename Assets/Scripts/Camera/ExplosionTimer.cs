using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour {

    public float delay = 0f;
    
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

}
