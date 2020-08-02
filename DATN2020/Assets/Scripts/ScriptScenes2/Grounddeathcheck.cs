using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounddeathcheck : MonoBehaviour
{
    public Player player;   


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // player.Damage(3);// dặm bẫy trừ đi 3hp
            player.ourHealth -= 1;        
        }

    }
    
}
