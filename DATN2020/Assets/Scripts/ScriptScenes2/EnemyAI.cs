using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;
    public Player player;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    //hp eagle
    public int maxHealth = 100;
    public HealthBar healthBar;
    public Slider slider;
    private Animator anim;
    public AudioSource boom;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
        boom = gameObject.GetComponent<AudioSource>();
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
     void Update()
    {
        DeathEagle();
    }
    void FixedUpdate()
    {
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            //enemyGFX.localScale = new Vector3(-1f, 1f, 1f);      
            transform.localScale = new Vector3(-1f, 1f, 1f);
            healthBar.transform.localScale = new Vector3(-1, 1);
        }
        else if (force.x <= -0.01f)
        {
            //enemyGFX.localScale = new Vector3(1f, 1f, 1f);          
            transform.localScale = new Vector3(1f, 1f, 1f);
            healthBar.transform.localScale = new Vector3(1, 1);
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag == "Player")
        //{
        //    player.Damage(40); //mất 20 máu
        //                       //knock khi chạm
        //    if (col.transform.position.x < transform.position.x)
        //    {
        //        player.Knockbackop(-100f, player.transform.position, true);//50f
        //    }
        //    else
        //    {
        //        player.Knockbackop(100f, player.transform.position, false);
        //    }
        //}
        if (col.gameObject.tag == "Player")
        {
            player.Damage(40); //mất 20 máu
            //player.KnockbackOpposum(200f, player.transform.position);
            if (col.transform.position.x < transform.position.x)
            {
                player.Knockbackop(10f, true);
            }
            else
            {
                player.Knockbackop(10f, false);
            }
        }
    }
    public void Knockbackscreep()
    {
        Vector2 temp = gameObject.transform.position;
        if (player.faceright == true)
        {
            rb.AddForce(new Vector2(temp.x * 5f, temp.y));
        }
        else
        {
            rb.AddForce(new Vector2(temp.x * 5f, temp.y));//khi quay đầu
        }
    }
    void Damage(int damage)
    {
        maxHealth -= damage;
        healthBar.SetHealth(maxHealth);
    }
    void DeathEagle()
    {
        if (maxHealth <= 0)
        {
            anim.SetTrigger("DeathEagle");
        }
    }
    void Explosive()
    {
        Destroy(this.gameObject);
    }
    public void Boom()
    {
        boom.Play();
    }
}
