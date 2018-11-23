using UnityEngine;
using UnityEngine.UI;

public class Block : BaseObject {

    public Text __number_text;

    void Start()
    {
        __power = Random.Range(2, 4);
        __number_text.text = __power.ToString();

        Tool.Palette palette = Tool.ColorUtility.GetPalette(__power);
        __number_text.color = palette.text;
        GetComponent<SpriteRenderer>().color = palette.background;
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