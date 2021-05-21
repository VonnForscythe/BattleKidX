using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage;
   // public GameObject destroyEffect;
    public Vector2 forward;

    private Transform player;
    private Vector2 target;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                //  Debug.Log("enemy Must Take Damage!");
                hitInfo.collider.GetComponent<PlayerController>().TakeDamage(damage);               //Need to change with Player health
            }
            DestroyProjectile();
        }

        transform.Translate(forward * speed * Time.deltaTime);
        //Debug.LogError(forward);

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        //GameObject deathEffect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
       // Destroy(deathEffect, 1.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.queriesStartInColliders = false;
        //    Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }







}
