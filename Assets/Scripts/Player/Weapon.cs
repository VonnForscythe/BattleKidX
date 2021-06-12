using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Weapon : MonoBehaviour
{
    public float offset;
    private float moveInput;
    public float speed;
    private Rigidbody2D rb;

    public Projectile projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
    //private bool facingRight = true;

    public AudioMixerGroup audioMixer;
    AudioSource playerFireAudioSource;
    public AudioClip playerFireSFX;

    void Update()
    {
        //{
        if (Time.timeScale != 0)
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Projectile temp = Instantiate(projectile, shotPoint.position, transform.rotation);
                    temp.forward = transform.right;
                    timeBtwShots = startTimeBtwShots;

                    if (!playerFireAudioSource)
                    {
                        playerFireAudioSource = gameObject.AddComponent<AudioSource>();
                        playerFireAudioSource.clip = playerFireSFX;
                        playerFireAudioSource.outputAudioMixerGroup = audioMixer;
                        playerFireAudioSource.loop = false;
                    }
                    playerFireAudioSource.Play();
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        //  }
        if (Time.timeScale != 0)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotZ); // - offset);
        }
    }

    //void FixedUpdate()
    //{
    //    moveInput = Input.GetAxis("Horizontal");
    //    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);              //Flip gun control

    //    if (facingRight == false && moveInput > 0)
    //    {
    //        Flip();
    //    }
    //    else if (facingRight == true && moveInput < 0)
    //    {
    //        Flip();
    //    }
    //}

    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    Vector3 Scaler = transform.localScale;
    //    Scaler.x *= -1;
    //    transform.localScale = Scaler;
    //}
}