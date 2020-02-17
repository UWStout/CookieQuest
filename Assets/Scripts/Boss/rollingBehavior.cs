using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingBehavior : StateMachineBehaviour
{
<<<<<<< HEAD
    private float timer;
    public float minTime;
    public float maxTime;
    public Sprite rollingSprite;

    private Transform cookie;
    private Transform trans;
    private Transform playerPos;
    private SpriteRenderer displayedSprite;
    public float speed;
    private Vector2 target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime);
        displayedSprite = GameObject.FindObjectOfType<SpriteRenderer>();
        target = new Vector2(playerPos.position.x, animator.transform.position.y);
        cookie = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
=======
    //public BoxCollider2D feetCol;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //feetCol.enabled = false;
>>>>>>> d4eaabf20832a15d602333cd06690bcc6601c6ba
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
<<<<<<< HEAD
        //displayedSprite.sprite = rollingSprite;
        if(timer <= 0)
        {
            animator.SetTrigger("Idle");
        } else
        {
            timer -= Time.deltaTime;
        }

        
        Vector2 cookiePos = new Vector2(animator.transform.position.x, animator.transform.position.y);
        Vector2 rollDir = target - cookiePos;


        cookie.transform.localRotation = Quaternion.Euler(cookie.transform.localRotation.x, cookie.transform.localRotation.y, cookie.transform.localRotation.z + 1);


        //animator.transform.Translate(direction * (speed * Time.deltaTime);
        //animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        animator.transform.Translate(rollDir * speed * Time.deltaTime);
=======

>>>>>>> d4eaabf20832a15d602333cd06690bcc6601c6ba
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
