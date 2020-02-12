using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float cooldown;

    private Animator anim;
    private GameObject[] enemies;
    private Vector3 loc;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("hit");
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies) {
                loc = enemy.GetComponent<Transform>().position;
                if(loc.x <= this.transform.position.x )
                {

                }
            }      
        }
    }


}
