using UnityEngine;
using UnityEngine.UI;

public class Block : BaseObject {

    public Text __number_text;
    public BlockType __type = BlockType.__normal;

    void Start()
    {
        Vector3 scale = transform.localScale;
        switch (__type) {
            case BlockType.__normal:
                scale.x = 0.3f;
                break;
            case BlockType.__long:
                scale.x = 3f;
                break;
            default:
                string msg = "Invalid block type. type: " + __type.ToString();
                throw new System.Exception(msg);
        }
        transform.localScale = scale;

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