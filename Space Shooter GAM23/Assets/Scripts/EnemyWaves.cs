using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{

    public bool canSpawn = true;
    public bool enter = true;
    public bool exit = true;
    public GameObject Spawner1 = null;


    public void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            StartCoroutine(StartSpawn());
        }
    }



    IEnumerator StartSpawn()
    {

        canSpawn = false;
        Spawner1.SetActive(true);
        yield return new WaitForSeconds(5f);
        Spawner1.SetActive(false);
       
        



    }
}

