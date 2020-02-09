using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int health;
    public int damage;

    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        healthBar.maxValue = health;
    }



    

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health; 
    }
}
