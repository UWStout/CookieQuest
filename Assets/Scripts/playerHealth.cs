using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public Slider healthBar;
    public int maxHealth = 10;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        healthBar.value = currentHealth;
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        

        //DEATH ANINATION


    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //DIE ANIMATION

        //DISABLE THE ENEMY
    }

}
