using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDash : MonoBehaviour
{
    private Rigidbody rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public float speed;
    public float coolDown = 1;
    public float coolDownTimer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime;
            }

            if( coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (direction == 0)
        {
            if (Input.GetButton("Left") && Input.GetKeyDown(KeyCode.Keypad3) && coolDownTimer == 0)
            {
                direction = 1;
                print("Dodging Left!!");
                coolDownTimer = coolDown;
            }
            else if (Input.GetButton("Right") && Input.GetKeyDown(KeyCode.Keypad3) && coolDownTimer == 0)
            {
                direction = 2;
                print("Dodging Right!!");
                coolDownTimer = coolDown;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector3.zero;

            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speed * dashSpeed);

                }
                else if (direction == 2)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speed * dashSpeed);

                }
            }
        }
    }
}
        
    




