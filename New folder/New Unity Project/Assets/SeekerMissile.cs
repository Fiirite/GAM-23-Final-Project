using UnityEngine;
using System.Collections;

public class SeekerMissile : MonoBehaviour
{
    public string searchTag;
    public GameObject closetMissle;
    public Transform target;

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
        transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterShip>())
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.GetComponent<CharacterShip>())
        {
            //other.gameObject.GetComponent<jsdjsj>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
