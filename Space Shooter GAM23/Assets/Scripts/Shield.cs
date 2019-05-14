using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield = null;
    public bool isUsingShield = false;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shield.SetActive(true);
            isUsingShield = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shield.SetActive(false);
            isUsingShield = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (isUsingShield == true)
        {
            //don't take damage
        }
        else
        {
            //take damage
        }
    }

}
