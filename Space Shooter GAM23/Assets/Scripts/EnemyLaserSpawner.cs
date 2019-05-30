using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserSpawner : MonoBehaviour
{
    public EnemyLaser weapon;

    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, 1f);
    }
    void LaunchProjectile()
    {
        Debug.Log("forward: " + transform.forward);

        EnemyLaser go = Instantiate(weapon, transform.position, transform.rotation);

        Destroy(go.gameObject, 5f);
    }
    void Update()
    {
    }
}
