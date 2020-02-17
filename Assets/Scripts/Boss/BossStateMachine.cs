using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStateMachine : MonoBehaviour
{
    //internals 
    private bool isFirst;

    //Components of this object
    public Animator anim;

    //State Machine 
    private float timer;
    public float minTime;
    public float maxTime;
    public GameObject player;
    private Transform playerTrans;

    //rolling
    public float rollSpeed;
    public Transform parentTrans;

    //coliders
    public BoxCollider2D feetCol;

    //Enumeration to switch between main boss states.
    private enum State
    {
        Idle,
        Rolling,
        Throwing
    }

    //instance of the above enum to control states for the boss.
    private State bossState;

    // Start is called before the first frame update
    void Start()
    {
        bossState = State.Idle;
        isFirst = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Switch on the enumeration made above, this controls the state machines base use. Switching to each state based on the each function within. 
        switch (bossState)
        {
            //Idle State, shows the boss bouncing in idle animation and counts the timer down until switching to the rolling behaviour again. 
            case State.Idle:
                //Only runs first frame in this state for each iteration. 
                if (isFirst == true)
                {
                    timer = 2;
                    isFirst = false;
                    anim.ResetTrigger("Rolling");
                }
                //Every frame stuff.
                idleState();
                timer -= Time.deltaTime;
                break;

            case State.Rolling:
                //First Frame in this state stuff.
                if (isFirst == true)
                {
                    timer = 5;
                    isFirst = false;
                    anim.ResetTrigger("Idle");
                }
                //Every Frame in this state.
                rollingState();
                timer -= Time.deltaTime;
                break;
            //Currently unused state.
            case State.Throwing:

                break;

        }
    }

    private void idleState()
    {
        //Renable Foot Colider to put the character back to correct height. 
        feetCol.enabled = true;

        //Set animation back to idle.
        anim.SetTrigger("Idle");

        //When timer goes under 0 switch to rolling state. Flip back to is first time so timer will reset in rolling.
        if (timer <= 0)
        {
            bossState = State.Rolling;
            isFirst = true;
        }

    }

    private void rollingState()
    {
        //Disable Feet Collider
        feetCol.enabled = false;

        //set the animation
        anim.SetTrigger("Rolling");

        //get all vector info we need to move the cookie correctly
        Vector2 target = new Vector2(player.transform.position.x, gameObject.transform.position.y);
        Vector2 cookiePos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 rollDir = target - cookiePos;

        //Rotate the gameObject to simulate rolling. 
        Vector3 rotation = new Vector3(0,0,1);
        gameObject.transform.Rotate(Vector3.forward, -90f * Time.deltaTime);
        
        //Move the parent objects transform to show movement of the sprite.
        parentTrans.position = Vector2.MoveTowards(parentTrans.position, target, rollSpeed * Time.deltaTime);

        //When timer goes under 0 set state back to idle, and set isFirst back so timer gets reset when changing to the new state. 
        if (timer <= 0)
        {
            bossState = State.Idle;
            isFirst = true;
        }


    }

    //Unused but would create random timing on state movement. 
    private float randomTimer()
    {
        float f = Random.Range(minTime, maxTime);
        return f;
    }
}