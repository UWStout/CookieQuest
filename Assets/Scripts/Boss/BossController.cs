using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int health;
    public int damage;

    public Slider healthBar;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = 10;
        healthBar.maxValue = health;
    }



    

    // Update is called once per frame
    void Update()
    {
        if(health <= health/2)
        {
            anim.SetTrigger("Stage2");
        }
        healthBar.value = health; 
    }
}
