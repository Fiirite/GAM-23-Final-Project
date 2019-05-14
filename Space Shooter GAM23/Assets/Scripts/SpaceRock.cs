using UnityEngine;
using System.Collections;

public class SpaceRock : MonoBehaviour
{
    public Vector3 rotationVector = Vector3.zero;
    public Vector3 movementVector = Vector3.zero;

    public float minRotation = -40.0f;
    public float maxRotation = 40.0f;

    public float minMovement = -1.0f;
    public float maxMovement = 1.0f;

    public float minSize = 1.0f;
    public float maxSize = 3.0f;
    public GameObject ExplosionPrefab = null;

	// Use this for initialization
	void Start ()
    {
        rotationVector = new Vector3(0.0f, 0.0f, Random.Range(minRotation, maxRotation));
        movementVector = new Vector3(Random.Range(minMovement, maxMovement), Random.Range(minMovement, maxMovement), 0.0f);
        transform.localScale = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), 1.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
        transform.position = transform.position + movementVector * Time.deltaTime;
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laser(Clone)")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Missile(Clone)")
        {
            Destroy(gameObject);
        }
        Instantiate(ExplosionPrefab,transform.position, Quaternion.identity);
    }
}

