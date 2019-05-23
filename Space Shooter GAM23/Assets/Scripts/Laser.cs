using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float speed = 10.0f;

    public GameObject Explosion;
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
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Laser: OnCollisionEnter");

        Instantiate(Explosion, transform.position, transform.rotation);

        collision.gameObject.SendMessage("addScore");

        Destroy(gameObject);

        Destroy(collision.gameObject);
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
