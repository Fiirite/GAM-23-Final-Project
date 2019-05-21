using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaspAI : MonoBehaviour {

    public float speed = 5f;
    private Vector3 direction = -Vector3.forward;

    IEnumerator Movelogic(){
        yield return new WaitForSeconds(.5f);
        direction = Vector3.left;
        yield return new WaitForSeconds(3f);
        direction = Vector3.right;
        yield return new WaitForSeconds(6f);
        direction = -Vector3.forward;
        yield return null;
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(Movelogic());
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * Time.deltaTime * speed;
	}
}
