using UnityEngine;
using System.Collections;

public class CharacterShip : MonoBehaviour
{
    public GameObject Shipmodel;

    public KeyCode moveUpInput = KeyCode.W;
    public KeyCode moveDownInput = KeyCode.S;
    public KeyCode moveLeftInput = KeyCode.A;
    public KeyCode moveRightInput = KeyCode.D;

    public GameObject laserPrefab = null;
    public GameObject missilePrefab = null;

    public KeyCode fireInput = KeyCode.UpArrow;
    public KeyCode missileInput = KeyCode.LeftArrow;
    public float laserRateofFire = 0.5f;
    public bool canShootLaser = true;
    public float laserCooldownTimer = 0.0f;
    public float missileRateofFire = 3.0f;
    public bool canShootmissile = true;
    public float missileCooldownTimer = 0.0f;
    public float tiltAngle;

    

    public float speed = 3.5f;
    //This is an Array
    public GameObject[] weaponPlacements;

    // Use this for initialization
    void Start()
    {

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

    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    public void HandleFire()
    {
        missileCooldownTimer += Time.deltaTime;
        laserCooldownTimer += Time.deltaTime;
        if (Input.GetKeyDown(fireInput))
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

        {
            float moveLR = Input.GetAxis("Horizontal");
            float moveFB = Input.GetAxis("Vertical");
            Shipmodel.transform.rotation = Quaternion.Euler(Vector3.forward * moveLR * -tiltAngle);
        }

    }
}
