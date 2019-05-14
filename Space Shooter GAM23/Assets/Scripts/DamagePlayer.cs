using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int PlayerHealth = 30;
    int damage = 10;

    void start ()
    {
        print(PlayerHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="enemy")
        {
            PlayerHealth -= damage;
            print("Shields Damaged!!!" + PlayerHealth);
        }
    }











}
