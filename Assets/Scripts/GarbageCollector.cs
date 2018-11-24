using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {
    public bool __is_running = true;
    public float __speed;

    void Update()
    {
        if (__is_running) {
            Vector2 dist = new Vector2(0f, 1f);
            Move(dist, __speed);
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag != "Player") {
            Destroy(c.gameObject);
        }
    }

    protected void Move(Vector2 dist, float speed)
    {
        Vector2 pos = transform.position;
        Vector2 newPos = pos + dist.normalized * speed;
        transform.position = newPos;
    }
}
