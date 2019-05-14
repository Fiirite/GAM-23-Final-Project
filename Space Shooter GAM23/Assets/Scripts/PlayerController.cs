using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float tiltAngle;
    public float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical , 0);
        rb.velocity = movement * moveSpeed;
        
   

        rb.rotation = Quaternion.Euler(Vector3.up * moveHorizontal * -tiltAngle);
    }
}