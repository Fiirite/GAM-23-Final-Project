using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player = null;
    public float speed = 1.0f;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime * speed);

        }
    }
        
    void OnCollisionEnter(Collision other)
    {
     
    }
}
