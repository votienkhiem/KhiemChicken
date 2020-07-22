using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public Animator anim;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void Boom()
    {
        anim.SetTrigger("Explosive");
    }
    public void Explosive()
    {
        Destroy(this.gameObject);
    }

}
