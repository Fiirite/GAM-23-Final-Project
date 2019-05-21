using UnityEngine;
using System.Collections;
[System.Serializable]


public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class CharacterShip : MonoBehaviour
{
    public KeyCode moveUpInput = KeyCode.W;
    public KeyCode moveDownInput = KeyCode.S;
    public KeyCode moveLeftInput = KeyCode.A;
    public KeyCode moveRightInput = KeyCode.D;
    public KeyCode DodgeInput = KeyCode.P;

    public GameObject laserPrefab = null;
    public GameObject missilePrefab = null;
    public GameObject Explosion;
    public GameObject Dodge = null;
    public Animator animator;
    

    public KeyCode fireInput = KeyCode.UpArrow;
    public KeyCode missileInput = KeyCode.LeftArrow;
    public float laserRateofFire = 0.5f;
    public bool canShootLaser = true;
    public float laserCooldownTimer = 0.0f;
    public float missileRateofFire = 3.0f;
    public bool canShootmissile = true;
    public float missileCooldownTimer = 0.0f;
    public bool canDodge = true;

    public float speed = 3.5f;
    //This is an Array
    public GameObject[] weaponPlacements;

   
    public float tiltAngle;
    public float moveSpeed;
    public GameObject Mainship = null;
    public Rigidbody rb;
    public Boundary boundary;


    public static CharacterShip Player;

    // Use this for initialization

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Awake()
    {
        Player = this;
        
    }



    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        Mainship.transform.rotation = Quaternion.Euler(Vector3.forward * moveHorizontal * -tiltAngle);
    }

    // Update is called once per frame
    void Update()
    {
        HandleFire();

        if (Input.GetKey(moveUpInput))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(moveDownInput))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(moveLeftInput))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(moveRightInput))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (canDodge && Input.GetKey(DodgeInput))
        {
            StartCoroutine(StartDodge());
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
         (
          Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
          0.0f,
          Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
          );


    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("OnCollisionEnter: " + collision.gameObject.name);

        Instantiate(Explosion, transform.position, transform.rotation);

        Destroy(gameObject);

        Destroy(collision.gameObject);
    }

    public void HandleFire()
    {
        missileCooldownTimer += Time.deltaTime;
        laserCooldownTimer += Time.deltaTime;
        if (Input.GetKey(fireInput))
        {
            if (canShootLaser == true)
            {
                for (int i = 0; i < weaponPlacements.Length; i++)
                {
                    Instantiate(laserPrefab, weaponPlacements[i].transform.position, Quaternion.identity);
                }
                canShootLaser = false;
                laserCooldownTimer = 0.0f;
            }

        }
        if (laserCooldownTimer >= laserRateofFire)
        {
            canShootLaser = true;
        }

        if (Input.GetKeyDown(missileInput))
        {
            if (canShootmissile == true)
            {

                for (int i = 0; i < 2; i++)
                {

                    Instantiate(missilePrefab, weaponPlacements[i].transform.position, weaponPlacements[i].transform.rotation);
                }
                canShootmissile = false;
                missileCooldownTimer = 0;
            }

        }
        if (missileCooldownTimer >= missileRateofFire)
        {
            canShootmissile = true;
        }
    }

    IEnumerator StartDodge()
    {
        animator.enabled = true;
        canDodge = false;
        Dodge.SetActive(true);
        animator.Play("Ship_Dodge");
        yield return new WaitForSeconds(1.0f);
        animator.enabled = false;
        Dodge.SetActive(false);
        yield return new WaitForSeconds(2f);
        canDodge = true;


      

    }



}
