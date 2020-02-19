using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float cooldown;
    private float timer;
    private int health;


    public Animator anim;
    public GameObject bossParent;

    private Vector3 loc;
    private BossBase bossScript;
    public Animator bossAnim;


    // Start is called before the first frame update
    void Start()
    {
        bossScript = bossParent.GetComponent<BossBase>();
        timer = 0;
        health = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && timer <= 0)
        {
            //Set Cooldown to start.
            timer = cooldown;

            //Set to hit animation state.
            anim.SetTrigger("hit");

            Debug.Log("Attack");
        }

        timer -= Time.deltaTime;
        anim.SetTrigger("idle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit taken");
        health--;
    }



}
