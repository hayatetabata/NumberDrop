using UnityEngine;
using UnityEngine.UI;

public class Block : BaseObject {

    public Text __number_text;

    void Start()
    {
        __power = Random.Range(2, 4);
        __number_text.text = __power.ToString();
    }

    // Update is called once per frame
    void Update () {
        Vector2 dist = new Vector2(0f, -1f);
        Move(dist, __speed);
    }

    protected override void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag != "Player") {
            return;
        }

        if (c.gameObject.GetComponent<Player>().__power > __power) {
            Destroy(gameObject);
        }
    }
}

public enum BlockType {
    __normal,
    __long
}