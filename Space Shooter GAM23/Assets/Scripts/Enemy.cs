using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player = null;
    public float speed = 1.0f;
	// Use this for initialization
	public Transform target;
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (player != null)
		if (gameObject.tag == "Player")
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime * speed);

        }
		transform.LookAt(target);
		transform.Translate(Vector3.forward *30.0f * Time.deltaTime);
    }
        
	void OnTriggerEnter (Collider other)
    {
		if (other.gameObject.tag == "Player")
			Destroy (other.gameObject);
    }
}
