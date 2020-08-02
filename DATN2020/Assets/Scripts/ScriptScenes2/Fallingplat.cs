using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplat : MonoBehaviour
{
    public Rigidbody2D r2;
    public float timedelay = 2;
    public Vector2 pos;
    // Use this for initialization
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        pos = r2.position;
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }      
    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        r2.bodyType = RigidbodyType2D.Dynamic;
        //reset lại cầu
        yield return new WaitForSeconds(10);
        r2.bodyType = RigidbodyType2D.Static;
        r2.position = pos;
        //end
        yield return 0;
    } 
}
