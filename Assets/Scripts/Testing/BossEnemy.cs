using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    GameObject player;

    Animator anim;
    SpriteRenderer sr;
    public int health;


    //public float distance;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");


        if (health <= 0)
        {
            health = 3;
        }

        //timeBtwShots = startTimeBtwShots;

        if (Time.time >= startTimeBtwShots + timeBtwShots)
        {
            //anim.SetBool("Fire", true);
            startTimeBtwShots = Time.time;
        }

    }

    void Update()
    {
        if (player)
        {
            if (player.transform.position.x < transform.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }

            float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (Vector2.Distance(transform.position, player.transform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance && Vector2.Distance(transform.position, player.transform.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.transform.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            }

            //if (timeBtwShots <= 0)
            //{
            //    Instantiate(projectile, transform.position, Quaternion.identity);

            //    timeBtwShots = startTimeBtwShots;
            //}
            //else
            //{
            //    timeBtwShots -= Time.deltaTime;
            //}


            //---------------------------------------------------------------------- Firing DIstance
            if (distToPlayer < 8)
            {
                if (timeBtwShots <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);

                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }
        else
        {
            if (GameManager.instance.playerInstance)
                player = GameManager.instance.playerInstance;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
