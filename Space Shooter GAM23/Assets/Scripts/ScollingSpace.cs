using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollingSpace : MonoBehaviour {

    public float speed = 1f;

	
// Update is called once per frame
	void Update ()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.y += Time.deltaTime * speed;

        mat.mainTextureOffset = offset;
	}
}
