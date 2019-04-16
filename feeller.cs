using UnityEngine;
using System.Collections;

public class feeller : MonoBehaviour
{
    public bool canMove = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "trigger")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            canMove = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "trigger")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            canMove = false;
        }
    }
}
