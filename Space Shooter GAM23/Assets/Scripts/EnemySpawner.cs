﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemySpawnPoints;
    public float spawnDelay = 3.0f;
    public float timer = 0.0f;
    public GameObject enemyPrefab = null;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnDelay)
        {
            int randomNumber = Random.Range(0, enemySpawnPoints.Length);
            Instantiate(enemyPrefab, enemySpawnPoints[randomNumber].transform.position, transform.rotation);
            timer = 0.0f;
        }
             
     
    }
}