using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBee : MonoBehaviour
{

    public float MoveSpeed = 5.0f;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    private Vector3 axis;

    private Vector3 pos;

    public Rigidbody rb;

    public GameObject Explosion;


    //private bool scoreAdded = false;


    void Start()
    {
        frequency = Random.Range(10f, 20f);
        magnitude = Random.Range(30f, 60f);

        rb = GetComponent<Rigidbody>();
        pos = transform.position;
        DestroyObject(gameObject, 10.0f);
        axis = new Vector3(1, 0, 0);  // May or may not be the axis you want

    }
    //public void addScore()
    //{
      //  if (scoreAdded)
      //      return;

       // scoreAdded = true;

       // Debug.Log("KillerBee score");

       // int current_score = PlayerPrefs.GetInt("Score", 0);

       // current_score += 10;  //score for killing enemy

       // PlayerPrefs.SetInt("Score", current_score);
    
  //  }

        void OnDestroy()
    {
        int score = PlayerPrefs.GetInt("Score", 0);

        score += 10;

        PlayerPrefs.SetInt("Score", score);

        Instantiate(Explosion, transform.position, transform.rotation);
    }

    void Update()
    {
        pos += new Vector3(0, 0, -1) * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
