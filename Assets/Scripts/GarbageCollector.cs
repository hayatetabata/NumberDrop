using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {
    public bool __is_running = true;

    void FixedUpdate()
    {
        if (__is_running) {
            Vector3 pos = transform.position;
            pos.y += 0.1f;
            transform.position = pos;
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag != "Player") {
            Destroy(c.gameObject);
        }
    }
}
