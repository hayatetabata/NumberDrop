using UnityEngine;

public class Elixer : BaseObject {

	// Update is called once per frame
    void Update () {
        Vector2 dist = new Vector2(0f, +1f);
        Move(dist, __speed);	
	}

    protected override void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
