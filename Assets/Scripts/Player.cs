using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int power;
    public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position.y < transform.position.y) {
            Move();
        }
    }

    void Move()
    {
        Vector2 pos = transform.position;
        Vector2 dist = new Vector2(0f, -1f);
        Vector2 newPos = pos + dist.normalized * speed;
        transform.position = newPos;
    }
}
