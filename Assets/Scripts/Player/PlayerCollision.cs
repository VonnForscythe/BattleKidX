using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerCollision : MonoBehaviour
{
    Health playerHealth;

    [Header("Audio")]
    public AudioMixerGroup audioMixer;
    AudioSource hurtAudioSource;
    public AudioClip hurtSFX;

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

            if (!hurtAudioSource)
            {
                hurtAudioSource = gameObject.AddComponent<AudioSource>();
                hurtAudioSource.clip = hurtSFX;
                hurtAudioSource.outputAudioMixerGroup = audioMixer;
                hurtAudioSource.loop = false;
            }
            hurtAudioSource.Play();

        }

    }
}