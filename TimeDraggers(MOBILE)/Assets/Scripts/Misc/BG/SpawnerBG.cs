using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBG : MonoBehaviour
{
    public float SpawnRate;
    public GameObject ToSpawn;


    private void Start()
    {
        InvokeRepeating("Spawn", 1, SpawnRate);
    }
    void Spawn()
    {
        Instantiate(ToSpawn, transform.position, transform.rotation, transform);
    }


}
