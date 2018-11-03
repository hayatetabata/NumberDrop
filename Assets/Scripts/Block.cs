using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : BaseObject {

	// Update is called once per frame
	void Update () {
        Vector2 dist = new Vector2(0f, +1f);
        Move(dist, __speed);
    }
}
