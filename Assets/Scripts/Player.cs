using UnityEngine;

public class Player : BaseObject {

    public int __power;

	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position.y < transform.position.y) {
            Vector2 dist = new Vector2(0f, -1f);
            Move(dist, __speed);
        }
    }
}
