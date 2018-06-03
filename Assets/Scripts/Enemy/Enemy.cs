using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Transform PlayerTransform;
    private Animator EnemyAnimator;
    public GameObject SwordSlash;
    float Distance;
    private bool StartAttackAnimation;
    float AttackTimer = 0;

	// Use this for initialization
	void Start () {

        EnemyAnimator = gameObject.GetComponent<Animator>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

        DistanceCalculator();

        NearPlayer();

        EnemyAnimator.SetBool("PlayerNear", StartAttackAnimation);

        InstantiateSwordSlash(NearPlayer());

        
    }

    void DistanceCalculator()
    {
        Distance = Vector3.Distance(PlayerTransform.position, gameObject.transform.position);
    }

    public bool NearPlayer()
    {
        if (Distance <= 3f)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    void InstantiateSwordSlash(bool IsPlayerNear)
    {        
            AttackTimer -= Time.deltaTime;
            if (AttackTimer <= 0 && IsPlayerNear)
            {
                Vector3 AttackPosition = transform.position + new Vector3(-1f, 0, 0);
                GameObject SwordAttackInstantiate = Instantiate(SwordSlash, AttackPosition, Quaternion.identity);
                StartAttackAnimation = true;
                AttackTimer = 1f;
            } else
            {
                StartAttackAnimation = false;
            }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shuriken")
        {
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "PlayerSlash")
        {
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
