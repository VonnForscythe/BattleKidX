using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    public LevelManager currentLevel;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Objective Met");
            if (SceneManager.GetActiveScene().name == "SampleScene")
                SceneManager.LoadScene("VictoryScreen");
            else if (SceneManager.GetActiveScene().name == "EndScreen")
                SceneManager.LoadScene("TitleScreen");
        }
    }





}
