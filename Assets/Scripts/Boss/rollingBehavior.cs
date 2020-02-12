using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingBehavior : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;
    public Sprite rollingSprite;

    private GameObject parent;
    private Transform trans;
    private Transform playerPos;
    private SpriteRenderer displayedSprite;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime);
        displayedSprite = GameObject.FindObjectOfType<SpriteRenderer>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        displayedSprite.sprite = rollingSprite;
        if(timer <= 0)
        {
            animator.SetTrigger("Idle");
        } else
        {
            timer -= Time.deltaTime;
        }

        Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);
        Vector2 cookie = new Vector2(animator.transform.position.x, animator.transform.position.y);
        float direction;
        direction = Vector2.Dot(cookie, target);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);   
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
