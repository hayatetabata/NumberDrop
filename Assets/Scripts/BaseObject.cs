using UnityEngine;

public abstract class BaseObject : MonoBehaviour {

    public int __power = 1;
    public float __speed;

    protected void Move(Vector2 dist, float speed)
    {
        Vector2 pos = transform.position;
        Vector2 newPos = pos + dist.normalized * speed;
        transform.position = newPos;
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
