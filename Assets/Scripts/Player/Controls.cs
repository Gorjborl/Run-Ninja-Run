using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public float HorizontalSpeed = 10f;
    private bool Move;
    private Animator MovementAnimator;
    private Rigidbody2D PlayerBody;
    

	// Use this for initialization
	void Start () {

        MovementAnimator = gameObject.GetComponent<Animator>();
        PlayerBody = gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        
        
        float horizontal = Input.GetAxis("Horizontal");

        MovementAnimator.SetBool("Move", IsMoving(horizontal));

        HandleMovement(horizontal);

        MovementFacing(horizontal);
        
    }

    void HandleMovement(float horizontal)
    {
        PlayerBody.velocity = new Vector2(horizontal * HorizontalSpeed, PlayerBody.velocity.y);
    }

    bool  IsMoving(float horizontal)
    {
        if ( horizontal != 0 )
        {
            Move = true;
        }
        else
        {
            Move = false;
        }

        return Move;
               
    }

    void MovementFacing( float horizontal )
    {
        if (horizontal > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (horizontal < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }    
        
}
