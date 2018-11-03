using UnityEngine;

public abstract class BaseObject : MonoBehaviour {

    public float __speed;

    protected void Move(Vector2 dist, float speed)
    {
        Vector2 pos = transform.position;
        Vector2 newPos = pos + dist.normalized * speed;
        transform.position = newPos;
    }
}
