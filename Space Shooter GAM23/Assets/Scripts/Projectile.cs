using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float MoveSpeed = 5.0f;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    private Vector3 axis;

    private Vector3 pos;

    public Rigidbody rb;

    void Start()
    {
        frequency = Random.Range(10f, 20f);
        magnitude = Random.Range(30f, 60f);

        rb = GetComponent<Rigidbody>();
        pos = transform.position;
        DestroyObject(gameObject, 10.0f);
        axis = new Vector3(1,0,0);  // May or may not be the axis you want

    }

    void Update()
    {
        pos += new Vector3(0,0,-1) * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
