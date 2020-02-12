using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [SerializeField]private LayerMask platformsLayerMask;
    private Player_Base playerBase;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    //the jump for the dinosaur if it is grounded and space
    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        LeftRightMovement();

    }

    //checks if the dinosaur is grounded
    private bool IsGrounded()
    {
       RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
       return raycastHit2d.collider != null;
    }

    //movement plus animation
    private void LeftRightMovement()
    {
        float movespeed = 5f;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetTrigger("walking");
            rigidbody2d.velocity = new Vector2(-movespeed, rigidbody2d.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetTrigger("Walking");
            rigidbody2d.velocity = new Vector2(+movespeed, rigidbody2d.velocity.y);
        }
        else
        {
            anim.SetTrigger("idle");
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }
    }

}
