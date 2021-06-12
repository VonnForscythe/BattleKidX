using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    AudioSource gameOverAudioSource;
    public AudioClip gameOverSFX;
    public AudioMixerGroup audioMixer;
    //public AudioMixer themeMusic;



    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }

            if (health <= 0)
            {
                //Invoke("Dying", 3);
                //if (!gameOverAudioSource)
                //{
                //    gameOverAudioSource = gameObject.AddComponent<AudioSource>();
                //    gameOverAudioSource.clip = gameOverSFX;
                //    gameOverAudioSource.outputAudioMixerGroup = audioMixer;
                //    gameOverAudioSource.loop = false;                    
                //}

                // StartCoroutine(DyingTimer());

                // IEnumerator DyingTimer()
                // {
                //     themeMusic.SetFloat("Music", -80);
                //     gameOverAudioSource.Play();

                //     yield return new WaitForSeconds(3);

                //    // gameOverAudioSource.Play();
                //     if (SceneManager.GetActiveScene().name == "SampleScene")
                //         SceneManager.LoadScene("Endscreen");
                // }
                //// gameOverAudioSource.Play();


                if (SceneManager.GetActiveScene().name == "SampleScene")
                    SceneManager.LoadScene("Endscreen");


            }
        }
    }

    //void Dying()
    //{
    //    gameOverAudioSource = gameObject.AddComponent<AudioSource>();
    //    gameOverAudioSource.clip = gameOverSFX;
    //    gameOverAudioSource.outputAudioMixerGroup = audioMixer;
    //    gameOverAudioSource.loop = false;

    //    gameOverAudioSource.Play();
    //    //yield return new WaitForSeconds(3);
    //    if (SceneManager.GetActiveScene().name == "SampleScene")
    //        SceneManager.LoadScene("Endscreen");
    //}
}
