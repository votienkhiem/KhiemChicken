using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundchecklv2 : MonoBehaviour
{

    public Player player;
    public Movingplat mov;

    public Vector3 movep;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();

        mov = GameObject.FindGameObjectWithTag("Movingplat").GetComponent<Movingplat>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;

        if (collision.isTrigger == false && collision.CompareTag("Movingplat"))
        {
            movep = player.transform.position;
            movep.x += mov.speed * 1.3f;
            player.transform.position = movep;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = false;
    }

}
