using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour {

    float __speed = 0.1f;
    float __life_time = 0f;
    float __max_life_time = 2f;

    // Update is called once per frame
    void Update () {
        __life_time += Time.deltaTime;
        if (__max_life_time < __life_time) {
            Destroy(gameObject);
            return;
        }
        Vector2 dist = new Vector2(0f, 1f);
        Move(dist, __speed); 
	}

    void Move(Vector2 dist, float speed) {
        Vector2 pos = transform.position;
        Vector2 newPos = pos + dist.normalized * speed;
        transform.position = newPos;
    }
}
