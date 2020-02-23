using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollDamage : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public int attackDamage = 1;
    public float attackRange;

    //ATTACKING

    void Battle()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<playerHealth>().TakeDamage(attackDamage);
        }
    }

    //HELPS SEE THE ATTACK RADIUS/RANGE
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
