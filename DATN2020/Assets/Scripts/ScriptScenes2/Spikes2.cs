using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes2 : MonoBehaviour
{
    public Player player;
    public SoundManager sound;

    // Use this for initialization
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            sound.Playsound("knock");
            player.Damage(30);// dặm bẫy trừ đi 1hp
            player.Knockback(30f, player.transform.position);//30f thông số nhảy khi chạm bẫy
        }
    }
}
 