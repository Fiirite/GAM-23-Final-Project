using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public Transform spawnPoint;


    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("Score", 0);

        Respawn();

    }

    public void PlayerDied()
    {
        Invoke("Respawn", 3f);
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
