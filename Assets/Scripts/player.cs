using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [SerializeField]private LayerMask platformsLayerMask;
    private Player_Base playerBase;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private Animator move;

    float jumpCooldown = .45f;
    float timeSinceAction = 0.0f;
  

    private player p;
    public bool isGrounded;
    public bool facingRight;
    private float groove;

    
    private void Awake()
    {
        move = GetComponent<Animator>();
        playerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        groove = Input.GetAxis("Horizontal;");
    }

    //the jump for the dinosaur if it is grounded and up-arrow pressed
    private void Update()
    {


        //when collides, it is grounded function
        // isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), platformsLayerMask);

        timeSinceAction += Time.deltaTime;

        //if grounded == true and up arrow pressed then he will jump
        if (timeSinceAction > jumpCooldown && Input.GetKeyDown(KeyCode.UpArrow))
        {
            timeSinceAction = 0;
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            move.SetBool("Moving", true);
        }

        LeftRightMovement();


        


    }

   
    //movement plus animation plus flip
    private void LeftRightMovement()
    {

        Vector2 characterscale = transform.localScale;
        

        float movespeed = 5f;

        if(Input.GetKey(KeyCode.LeftArrow))
        {

            rigidbody2d.velocity = new Vector2(-movespeed, rigidbody2d.velocity.y);
            // move.SetBool("Moving", true);
            //flips left if moving left
            if (groove > 0)
            {
                Flip();
            }
            
            characterscale.x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            rigidbody2d.velocity = new Vector2(+movespeed, rigidbody2d.velocity.y);
            //move.SetBool("Moving", true);
            //Flips right if moving right;
            if (groove < 0)
            {
                Flip();
            }
            characterscale.x = 1;

        }
        else
        {

            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        transform.localScale = characterscale;

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }


  
    

}


//previous codes (in case we need to go back to something)


//checks if the dinosaur is grounded (did not work)
/* private bool IsGrounded()
 {
    RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, platformsLayerMask);
     Debug.Log(raycastHit2d.collider);
    return raycastHit2d.collider != null;
 }
 */
