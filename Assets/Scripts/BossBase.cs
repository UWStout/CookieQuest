using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{

    public int health;
    public Animator bossAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("boss hit");
        TakeHit();
 
    }
    public void TakeHit()
    {
        //Debug.Log("Damage Taken");
        bossAnim.SetTrigger("Idle");
        health--;
    }
}
