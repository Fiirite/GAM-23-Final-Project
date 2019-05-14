using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float speed = 10.0f;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(WaitAndDestroy());
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = transform.position + Vector3.forward * Time.deltaTime * speed;
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
