using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed = 50f, maxspeed = 3f, jumpPow = 230f;
    public bool grounded = true, faceright = true, doublejump = false;

    //Máu nhân vật
    public int ourHealth = 3;
    public int maxhealth = 100;
    public int newhealth;
    public HealthBar healthBar;

    public Rigidbody2D r2;
    public Animator anim;
    //checkpoint
    public Vector3 location;

    //Điểm
    public Gamemaster gm;
    public Cherry cherry;
    public Gem gem;
    //Kiểm tra bất tử
    public bool immortal = false;
    //âm thanh
    public SoundManager sound;


    // Use this for initialization
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
        // ourHealth = maxhealth;
        newhealth = maxhealth;
        healthBar.SetMaxHealth(newhealth);
        cherry = gameObject.GetComponent<Cherry>();
        gem = gameObject.GetComponent<Gem>();
        location = transform.position;
        //âm thanh
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 1.5f);
                }
            }
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        ////giới hạn nhảy
        //if (r2.velocity.y > maxjump)
        //    r2.velocity = new Vector2(r2.velocity.x, maxjump);
        //if (r2.velocity.y < -maxjump)
        //    r2.velocity = new Vector2(r2.velocity.x, -maxjump);

        if (h > 0 && !faceright)
        {
            Flip();
            healthBar.checkScale();
        }

        if (h < 0 && faceright)
        {
            Flip();
            healthBar.checkScale();
        }
        // giảm ma sát(giảm tốc độ)
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.9f, r2.velocity.y);
        }
        //máu nhỏ 0 sẽ chết
        //if (ourHealth <= 0)
        //{
        //    Death();
        //}
        //mạng <=0 chết
        if (newhealth < 0)
        {
            sound.Playsound("herodie");
            ourHealth -= 1;
            newhealth = maxhealth;
            healthBar.SetMaxHealth(newhealth);
            StartCoroutine(BatTu());
        }

        if (ourHealth <= 0)
        {          
            Death();
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(PlayerPrefs.GetInt("highscore") < gm.points)
            PlayerPrefs.SetInt("highscore", gm.points);
    }
    //Start Bẫy chông
    public void Damage(int damage)
    {
        // ourHealth -= damage;
        if (immortal != true) 
        {
            newhealth -= damage;
            healthBar.SetHealth(newhealth); // set lại thanh máu hero
            gameObject.GetComponent<Animation>().Play("redflash");// nháy đỏ khi ng chơi mất hp
        }
    }
    //bẫy chông
    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * -35, Knockdir.y * Knockpow));//(-40 độ giật lùi khi chạm bẫy)
    }
    //End Bẫy chông
    public void Knockbackop(float Knockpow, Vector2 Knockdir, bool knockFromRight)//thay đổi độ bật lùi dựa knockdir và knockpow
    {
        r2.velocity = new Vector2(0, 0);
        if (knockFromRight)
        {
            r2.AddForce(new Vector2(Knockdir.x * Knockpow, Knockdir.y * -50));
        }
        if (!knockFromRight)
        {
            r2.AddForce(new Vector2(Knockdir.x * Knockpow, Knockdir.y * 50));
        }
    }
    //End Knockback người chơi chạm quái
    //Coins
    public void OnTriggerEnter2D(Collider2D col)
    {
        Cherry cherry = col.gameObject.GetComponent<Cherry>();
        Gem gem = col.gameObject.GetComponent<Gem>();

        if (col.CompareTag("Coins"))//Chạm trái cây có tag là coins
        {        
            gm.points += 100;// cộng điểm
            cherry.Boom();//thay đổi animation nổ
            sound.Playsound("coins");
        }      
        if (col.CompareTag("CoinsDiamond"))
        {
            //Destroy(col.gameObject);
            gm.points += 300;
            gem.Boom();
            sound.Playsound("coins");
        }
        //checkpoint
        if (col.CompareTag("CheckPoint"))
        {
            location = col.transform.position;
        }
        if (col.CompareTag("landDead"))
        {
            transform.position = location;
        }
        //tăng tốc độ di chuyển khi chạm giày
        if (col.CompareTag("Shoe"))
        {
            sound.Playsound("powerup");
            Destroy(col.gameObject);
            maxspeed = 4f;
            speed = 70f;
            StartCoroutine(timecount(20));
        }
    }
    //Endcoins
    //Start Bất tử
    public IEnumerator BatTu()
    {
        if(!immortal)
        {
            immortal = true;
            yield return new WaitForSeconds(3);
            immortal = false;
        }    
    }
    //End Bất tử
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Movingplat"))
            this.transform.parent = col.transform;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Movingplat"))
            this.transform.parent = null;
    }

    //thời gian đếm ngược đôi giày
    IEnumerator timecount(float time)
    {
        yield return new WaitForSeconds(time);
        maxspeed = 3f;
        speed = 50f;
        yield return 0;
    }
}