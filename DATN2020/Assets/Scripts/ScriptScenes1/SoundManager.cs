using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins, swords, destroy,win,herodie,knock,powerup;

    public AudioSource adisrc;
    // Use this for initialization
    void Start()
    {
        coins = Resources.Load<AudioClip>("coin");
        swords = Resources.Load<AudioClip>("Sword");
        destroy = Resources.Load<AudioClip>("Explosion");
        win = Resources.Load<AudioClip>("win");
        herodie = Resources.Load<AudioClip>("Hero_Death");
        knock = Resources.Load<AudioClip>("DM-CGS");
        adisrc = GetComponent<AudioSource>();
        powerup = Resources.Load<AudioClip>("power_up");
    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 1f);
                break;

            case "destroy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 0.1f);
                break;

            case "sword":
                adisrc.clip = swords;
                adisrc.PlayOneShot(swords, 1f);
                break;
            case "win":
                adisrc.clip = win;
                adisrc.PlayOneShot(win, 1f);
                break;
            case "herodie":
                adisrc.clip = herodie;
                adisrc.PlayOneShot(herodie, 1f);
                break;
            case "knock":
                adisrc.clip = knock;
                adisrc.PlayOneShot(knock, 1f);
                break;
            case "powerup":
                adisrc.clip = powerup;
                adisrc.PlayOneShot(powerup, 1f);
                break;
        }
    }
} 
