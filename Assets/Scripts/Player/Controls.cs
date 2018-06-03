using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour {

    public float HorizontalSpeed = 10f;
    public float JumpSpeed = 5f;
    private bool Move;
    private Animator MovementAnimator;
    private Rigidbody2D PlayerBody;
    private bool IsGrounded;
    private bool IsJumping;
    private bool SwordAttackBool;
    private bool ShurikenAttackBool;
    public float horizontal;

    public GameObject SwordAttack;
    public GameObject ShurikenAttack;
    public Button JumpButton;
    private bool JumpBtn;

    public Image HeartFilled1;
    public Image HeartFilled2;
    public Image HeartFilled3;
    public Image HeartEmpty1;
    public Image HeartEmpty2;
    public Image HeartEmpty3;
    private int PlayerLives;
    public Transform CameraPosition;
    Vector3 RespawnPosition;
    private bool Respawning;


    
	// Use this for initialization
	void Start () {

        PlayerLives = 3;
        MovementAnimator = gameObject.GetComponent<Animator>();
        PlayerBody = gameObject.GetComponent<Rigidbody2D>();
        
        
    }
	
	// Update is called once per frame
	void Update () {

        //horizontal = Input.GetAxis("Horizontal");

        horizontal = 0.8f;

        MovementAnimator.SetBool("Move", IsMoving(horizontal));

        MovementAnimator.SetBool("Attack", SwordAttackBool);

        MovementAnimator.SetBool("Throw", ShurikenAttackBool);

        MovementAnimator.SetBool("Jump", IsJumping);

        HandleMovement(horizontal);

        MovementFacing(horizontal);
        
        SwordAttackEffect(SwordAttackBool);

        SwordAttackBool = false;

        ShurikenThrow(ShurikenAttackBool);

        ShurikenAttackBool = false;
        
        RespawnPosition = new Vector3(CameraPosition.position.x - 4.35f, CameraPosition.position.y - 3.195001f, 0);

        PlayerFall();
        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            IsGrounded = true;
            IsJumping = false;
            Respawning = true;
        }


        if (collision.gameObject.tag == "EnemySlash")
        {
            PlayerLives--;
            UpdateLivesUI();
        }
    }

    void UpdateLivesUI()
    {
        if(PlayerLives == 3)
        {
            HeartFilled1.gameObject.SetActive(true);
            HeartFilled2.gameObject.SetActive(true);
            HeartFilled3.gameObject.SetActive(true);
            HeartEmpty1.gameObject.SetActive(false);
            HeartEmpty2.gameObject.SetActive(false);
            HeartEmpty3.gameObject.SetActive(false);
        }

        if (PlayerLives == 2)
        {
            HeartFilled1.gameObject.SetActive(true);
            HeartFilled2.gameObject.SetActive(true);
            HeartFilled3.gameObject.SetActive(false);
            HeartEmpty1.gameObject.SetActive(false);
            HeartEmpty2.gameObject.SetActive(false);
            HeartEmpty3.gameObject.SetActive(true);
        }

        if (PlayerLives == 1)
        {
            HeartFilled1.gameObject.SetActive(true);
            HeartFilled2.gameObject.SetActive(false);
            HeartFilled3.gameObject.SetActive(false);
            HeartEmpty1.gameObject.SetActive(false);
            HeartEmpty2.gameObject.SetActive(true);
            HeartEmpty3.gameObject.SetActive(true);
        }

        if (PlayerLives == 0)
        {
            HeartFilled1.gameObject.SetActive(false);
            HeartFilled2.gameObject.SetActive(false);
            HeartFilled3.gameObject.SetActive(false);
            HeartEmpty1.gameObject.SetActive(true);
            HeartEmpty2.gameObject.SetActive(true);
            HeartEmpty3.gameObject.SetActive(true);
        }
    }

    void PlayerFall()
    {
        if (gameObject.transform.position.y <= -5.5f)
        {
            PlayerLives--;
            UpdateLivesUI();
            Respawning = true;

        }
    }

    void RespawnPlayer( bool Respawning )
    {
        gameObject.transform.position = RespawnPosition;

    }

    public void Jumping()
    {
        if (IsGrounded)
        {
            PlayerBody.velocity = new Vector2(0, JumpSpeed);
            IsJumping = true;
            IsGrounded = false;
        }
        
    }

    public void Attacking()
    {
        SwordAttackBool = true;

    }

    public void ShurikenThrowing()
    {
        ShurikenAttackBool = true;
    }

    void SwordAttackEffect(bool IsAttacking)
    {
        if ( IsAttacking)
        {
            Vector3 AttackPosition = transform.position + new Vector3(1f, 0, 0);
            GameObject SwordAttackInstantiate = Instantiate(SwordAttack, AttackPosition, Quaternion.identity);
            
        }        
    }

    void ShurikenThrow(bool IsThrowing)
    {
        if (IsThrowing)
        {
            Vector3 AttackPosition = transform.position + new Vector3(0.5f, 0, 0);
            GameObject ShurikenInstantiate = Instantiate(ShurikenAttack, AttackPosition, Quaternion.identity);

        }

    }

    
}
