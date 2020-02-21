/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator hit;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

    }


    void Attack()
    {
        //Play an attack animation
        
        hit.SetTrigger("attack");

        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
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
    }
}