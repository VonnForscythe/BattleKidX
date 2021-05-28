using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if (player)
        {
            Vector3 cameraTransform;
            cameraTransform = transform.position;

            cameraTransform.x = player.transform.position.x - 0.5f;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, 0f, 174.4f);
            
            

            cameraTransform.y = player.transform.position.y - 0.5f;
            cameraTransform.y = Mathf.Clamp(cameraTransform.y, 0f, 46f);

            transform.position = cameraTransform;
        }
    }
}