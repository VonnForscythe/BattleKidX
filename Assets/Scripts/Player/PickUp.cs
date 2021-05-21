using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{ 
    public enum CollectibleType 
    { 
        POWERUP,
        Collectible,
        LIVES,
        Score
    }

    public CollectibleType currentCollectible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.POWERUP:
                    PlayerControllerv2 pmScript = collision.gameObject.GetComponent<PlayerControllerv2>();
                    pmScript.extraJumpsValue++;
                    
                    break;

                case CollectibleType.LIVES:
                    pmScript = collision.gameObject.GetComponent<PlayerControllerv2>();
                    pmScript.health++;
                   // Debug.Log(pmScript.health);
                    break;

                case CollectibleType.Score:
                    pmScript = collision.gameObject.GetComponent<PlayerControllerv2>();
                    pmScript.score++;
                    //Debug.Log(pmScript.score);
                    break;

                case CollectibleType.Collectible:
                    pmScript = collision.gameObject.GetComponent<PlayerControllerv2>();
                    pmScript.collectible++;
                    //Debug.Log(pmScript.Collectible);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
