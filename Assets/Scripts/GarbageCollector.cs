using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag != "Player") {
            Destroy(c.gameObject);
        }
    }
}
