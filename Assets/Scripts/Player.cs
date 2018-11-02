using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int power;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position.y > transform.position.y) {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
