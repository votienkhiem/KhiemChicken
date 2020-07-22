using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockPlayer : MonoBehaviour
{
    public Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    //Start Knockback người chơi chạm quái
    internal void Knockbackop(float Knockpow, Vector2 Knockdir, bool knockFromRight)
    {
        player.r2.velocity = new Vector2(0, 0);
        if (knockFromRight)
        {
            player.r2.AddForce(new Vector2(Knockdir.x * -600f, Knockdir.y * Knockpow));
        }
        if (!knockFromRight)
        {
            player.r2.AddForce(new Vector2(Knockdir.x * 600f, Knockdir.y * Knockpow));
        }
    }
    //End Knockback người chơi chạm quái
}
