using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{
    public int health = 1000;
    public GameObject deatheffect;


    public bool isInvulnerable = false; 
    public void TakeDame(int Damage)
    {
        
        if (isInvulnerable)
             return;
        health -= Damage;
        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged",true);
        }
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        // Instantiate(deatheffect, transform.position, quaternion.identity);
        Destroy(gameObject);
    }
    //
    public Slider slider;

    public void setMaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void sethealth(int health)
    {
        slider.value = health;
    }
}
