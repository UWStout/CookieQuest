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
   
    private enum State {
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
        switch(bossState)
        {
            case State.Idle:
                if (isFirst == true)
                {
                    timer = 3;
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
                    timer = 3;
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
        
        //playerTrans = player.GetComponent<Transform>();
        anim.SetTrigger("Rolling");
        Vector2 target = new Vector2(player.transform.position.x, gameObject.transform.position.y);
        Vector2 playerPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 rollDir = target - playerPos;


        gameObject.transform.localRotation = Quaternion.Euler(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z + 20);

        //gameObject.transform.Translate(rollDir * rollSpeed * Time.deltaTime);

        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target, rollSpeed * Time.deltaTime);

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
