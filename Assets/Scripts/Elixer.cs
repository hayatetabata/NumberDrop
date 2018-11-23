using UnityEngine;
using UnityEngine.UI;

public class Elixer : BaseObject {

    public Text __number_text;

    void Start()
    {
        __power = Random.Range(1, 3);
        __number_text.text = __power.ToString();
    }

    protected override void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
