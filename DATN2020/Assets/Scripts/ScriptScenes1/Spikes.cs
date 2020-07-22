using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Player player;
    public SoundManager sound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            sound.Playsound("knock");
            player.Damage(20);// dặm bẫy trừ đi 1hp
            player.Knockback(130f, player.transform.position);//130f thông số nhảy khi chạm bẫy
        }
    }
}