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
    private Transform player;

    //public float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //timeBtwShots = startTimeBtwShots;

        if (Time.time >= startTimeBtwShots + timeBtwShots)
        {
            //anim.SetBool("Fire", true);
            startTimeBtwShots = Time.time;
        }

    }

    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
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
}
