using UnityEngine;
using System.Collections;

public class SeekerMissile : MonoBehaviour
{
    public string searchTag;
    public GameObject closetMissle;
    public Transform target;
    public GameObject Explosion;

    void Start()
    {
        closetMissle = FindClosestEnemy();

        if (closetMissle)
            target = closetMissle.transform;

        StartCoroutine(WaitAndDestroy());
    }

    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * 300.0f * Time.deltaTime);
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(searchTag);

        GameObject closest = null;
        float distance = Mathf.Infinity;

        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        return closest;
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
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
