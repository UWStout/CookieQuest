using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 200;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }

        //DEATH ANINATION

        
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //DIE ANIMATION

        //DISABLE THE ENEMY
    }

    
}
