using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    //internals 
    public int health;
    public int damage;
    private bool isFirst;

    //UI
    public Slider healthBar;

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

    private enum State
    {
        Idle,
        Rolling,
        Throwing
    }

    private State bossState;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        //healthBar.maxValue = health;
        //anim = gameObject.GetComponent<Animator>();
        //player = GameObject.Find("Player");
        bossState = State.Idle;
        isFirst = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(timer);
        switch (bossState)
        {
            case State.Idle:
                if (isFirst == true)
                {
                    timer = 2;
                    isFirst = false;
                    anim.ResetTrigger("Rolling");
                    //Debug.Log("Timer Reset");
                }
                idleState();
                timer -= Time.deltaTime;
                //Debug.Log("IDLE");
                break;
            case State.Rolling:
                if (isFirst == true)
                {
                    timer = 5;
                    isFirst = false;
                    anim.ResetTrigger("Idle");
                    //Debug.Log("Timer Reset");
                }
                rollingState();
                timer -= Time.deltaTime;
                //Debug.Log("ROLLING");
                break;
            case State.Throwing:

                break;

        }
        //healthBar.value = health;

    }

    private void idleState()
    {
        anim.SetTrigger("Idle");
        if (timer <= 0)
        {
            bossState = State.Rolling;
            isFirst = true;
        }

    }

    private void rollingState()
    {
        //Debug.Log(parentTrans.position.x);
        //playerTrans = player.GetComponent<Transform>();

        //set the animation
        anim.SetTrigger("Rolling");

        //get all vector info we need to move the cookie correctly
        Vector2 target = new Vector2(player.transform.position.x, gameObject.transform.position.y);
        Vector2 cookiePos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 rollDir = target - cookiePos;

        //Debug.Log(target);
        //Debug.Log(rollDir);
        Vector3 rotation = new Vector3(0,0,1);
        //gameObject.transform.Rotate(rotation * Time.deltaTime);
        gameObject.transform.Rotate(Vector3.forward, -90f * Time.deltaTime);
        //gameObject.transform.localRotation = Quaternion.Euler(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z + 20);

        
        //parentTrans.Translate(rollDir * rollSpeed * Time.deltaTime);
        parentTrans.position = Vector2.MoveTowards(parentTrans.position, target, rollSpeed * Time.deltaTime);

        if (timer <= 0)
        {
            bossState = State.Idle;
            isFirst = true;
        }


    }

    private float randomTimer()
    {
        float f = Random.Range(minTime, maxTime);
        return f;
    }
}