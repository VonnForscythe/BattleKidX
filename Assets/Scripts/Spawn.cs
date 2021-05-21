using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefab;
    //public GameObject prefab;

    void Start()
    {
        //Instantiate(spawnedObject[0], transform.position, transform.rotation);
        //var position = SpawnPoint;
        //int Spawns = Random.Range(0, 4);
        Instantiate(prefab[Random.Range(0, 4)], transform.position, Quaternion.identity);
    }


}





