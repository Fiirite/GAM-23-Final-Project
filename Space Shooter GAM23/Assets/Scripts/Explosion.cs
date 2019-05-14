using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitAndDestroy());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
