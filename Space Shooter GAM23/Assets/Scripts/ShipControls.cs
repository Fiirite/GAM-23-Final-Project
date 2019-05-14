using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed;
    public float tiltAngle;

    public void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

	public void Update()
    {
        float moveLR = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveLR, moveFB, 0);
        rb.velocity = movement * moveSpeed;

        rb.rotation = Quaternion.Euler(Vector3.up * moveLR * -tiltAngle);
    }
}