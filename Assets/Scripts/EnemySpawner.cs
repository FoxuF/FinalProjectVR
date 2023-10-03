using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public bool spawn_1 = false;
    public bool spawn_2 = true;
    public bool spawn_3 = true;
    public bool spawn_4 = true;
    public bool spawn_5 = true;
    // Start is called before the first frame update
    private void Awake()
    {
        
        
    }

    void Start()
    {
        StartCoroutine(WaitForPlayer());
        Instantiate(enemyToSpawn, new Vector3(0, 1, 11.45f), quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.instance.timeLeft < 52.5 && spawn_2)
        {
            spawn_2 = false;
            Instantiate(enemyToSpawn, new Vector3(-10.32f, 1, 16.06f), quaternion.identity);
        }
        if (Timer.instance.timeLeft < 45 && spawn_3)
        {
            spawn_3 = false;
            Instantiate(enemyToSpawn, new Vector3(-16.78f, 4.28f, 9.77f), quaternion.identity);
        }
        if (Timer.instance.timeLeft < 37.5 && spawn_4)
        {
            spawn_4 = false;
            Instantiate(enemyToSpawn, new Vector3(-15.91f, 1.23f, 10.38f), quaternion.identity);
        }
        if (Timer.instance.timeLeft < 30 && spawn_5)
        {
            spawn_5 = false;
            Instantiate(enemyToSpawn, new Vector3(14.89f, 5.97f, 16.49f), quaternion.identity);
        }
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(5);
    }
}
