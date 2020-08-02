using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int AttackDame = 20;
    //cái này để biến hình mà chưa sài
    public int enrangeAttackdame = 40;
    //
    public Vector3 attackoffset;
    public float attackrange = 1f;

    public LayerMask attackmask;
    public AudioSource sword;
    void Start()
    {
        sword = gameObject.GetComponent<AudioSource>();
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackoffset.x;
        pos += transform.up * attackoffset.y;

        //Collider2D colinfo = Physics2D.OverlapCircle(pos, attackrange, attackmask);
        //Debug.Log(colinfo);
        //if (colinfo != null)
        //{
        //    colinfo.GetComponent<Player>().Damage(AttackDame);
        //}
        Collider2D colinfo = Physics2D.OverlapCircle(pos, attackrange, attackmask);
        if (colinfo != null)
        {
            Player hit = colinfo.GetComponent<Player>();
            hit.Damage(AttackDame);
            if (hit.transform.position.x < transform.position.x)
            {
                hit.Knockbackop(10f, true);
            }
            else
            {
                hit.Knockbackop(10f, false);
            }
        }
    }
    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackoffset.x;
        pos += transform.up * attackoffset.y;

        //Collider2D colinfo = Physics2D.OverlapCircle(pos, attackrange, attackmask);
        //if (colinfo != null)
        //{
        //    colinfo.GetComponent<Player>().Damage(AttackDame);
        //}
        Collider2D colinfo = Physics2D.OverlapCircle(pos, attackrange, attackmask);
        if (colinfo != null)
        {
            Player hit = colinfo.GetComponent<Player>();
            hit.Damage(enrangeAttackdame);
            if (hit.transform.position.x < transform.position.x)
            {
                hit.Knockbackop(10f, true);
            }
            else
            {
                hit.Knockbackop(10f, false);
            }
        }
    }
    public void Boom()
    {
        sword.Play();
    }
}
