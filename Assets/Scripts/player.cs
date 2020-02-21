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
    private float attackCool = .5f;
    private float attackCooled;
    private Animator jump;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public int attackDamage = 10;
    //public int damage;
    

    float jumpCooldown = .45f;
    float timeSinceAction = 0.0f;
    public float attackRange;
  

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
<<<<<<< HEAD

       

=======
>>>>>>> 5cc5489a876ddb81267d5190ce1cfed11c2f25ae
    }

    //the jump for the dinosaur if it is grounded and up-arrow pressed
    private void Update()
    {


        

        timeSinceAction += Time.deltaTime;
        attackCooled += Time.deltaTime;

        //if timer is 0 and up arrow pressed then he will jump
        if (timeSinceAction > jumpCooldown && Input.GetKeyDown(KeyCode.UpArrow))
        {
            timeSinceAction = 0;
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            move.SetTrigger("Jump");
        }

        LeftRightMovement();


        


    }

   
    //MOVEMENT, JUMP, HIT, AND ANIMATIONS
    private void LeftRightMovement()
    {

        Vector2 characterscale = transform.localScale;
        

        float movespeed = 5f;

        //LEFT MOVEMENT
        if(Input.GetKey(KeyCode.LeftArrow))
        {

            rigidbody2d.velocity = new Vector2(-movespeed, rigidbody2d.velocity.y);
            move.SetBool("Moving", true);
<<<<<<< HEAD
            move.SetBool("Idle", false);



=======
            //flips left if moving left
>>>>>>> 5cc5489a876ddb81267d5190ce1cfed11c2f25ae

            characterscale.x = -1;
        }
        //RIGHT MOVEMENT
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            rigidbody2d.velocity = new Vector2(+movespeed, rigidbody2d.velocity.y);

            move.SetBool("Moving", true);
<<<<<<< HEAD
            move.SetBool("Idle", false);


=======
            //Flips right if moving right;
>>>>>>> 5cc5489a876ddb81267d5190ce1cfed11c2f25ae

            characterscale.x = 1;

        }
        //PLAYER ATTACK WHEN SPACE IS PRESSED AND COOLDOWN IS DOWN
        else if (attackCooled > attackCool && Input.GetKey(KeyCode.Space))
        {
            move.SetTrigger("attack");
            Battle();
            attackCooled = 0;
        }

        //PLAYER IS IDLE
        else
        {
            move.SetBool("Moving", false);
            move.SetBool("Idle", true); 
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        transform.localScale = characterscale;

    }


    //PLAYER IS FLIPPING
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }


  
    //ATTACKING

    void Battle()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    //HELPS SEE THE ATTACK RADIUS/RANGE
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
















// groove = Input.GetAxis("Horizontal");

//previous codes (in case we need to go back to something)


//checks if the dinosaur is grounded (did not work)
/* private bool IsGrounded()
 {
    RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, platformsLayerMask);
     Debug.Log(raycastHit2d.collider);
    return raycastHit2d.collider != null;
 }
 */


 //flips left if moving left

          /*  if (groove > 0)
            {
                Flip();
            }*/


 //Flips right if moving right;

            

           /* if (groove < 0)
            {
                Flip();
            }*/


//when collides, it is grounded function
        // isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), platformsLayerMask);