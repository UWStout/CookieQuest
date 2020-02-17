using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float cooldown;
    private float timer;


    public Animator anim;
    public GameObject bossParent;

    private Vector3 loc;
    private BossBase bossScript;


    // Start is called before the first frame update
    void Start()
    {
        bossScript = bossParent.GetComponent<BossBase>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && timer <= 0)
        {
            //Set Cooldown to start.
            timer = cooldown;
            //Set to hit animation state.
            //anim.SetTrigger("hit");



            //Debug.Log("Hitting");

            bossScript.TakeHit();
        }

        timer -= Time.deltaTime;
    }

    void OnTriggerEnter()
    {
        Debug.Log("entered");
    }



}
