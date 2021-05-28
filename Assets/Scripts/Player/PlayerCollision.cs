using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Health playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "BossShot")
        //{
        //    playerHealth.health--;
        //    Destroy(collision.gameObject);
        //}

        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth.health--;
        }

    }
}