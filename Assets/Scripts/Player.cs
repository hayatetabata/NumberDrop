using UnityEngine;
using UnityEngine.UI;

public class Player : BaseObject {

    public Text __number_text;
    public GameController gameController;
    Vector2 __src;
    Vector2 __dist;

    // Update is called once per frame
    void Update () {
        __number_text.text = __power.ToString();

        if (Camera.main.transform.position.y < transform.position.y) {
            Vector2 dist = new Vector2(0f, -1f);
            Move(dist, __speed);
        }
    }

    void FixedUpdate()
    {
        string touchType = TouchDetector.Detect();
        if (touchType == TouchEventKeys.IsTouched) {
            //Update __src
        }

        if (touchType == TouchEventKeys.WasTouched) {
            //Diff __src and current pos
            //Substitute diff to transform.pos
            //Update __src by current pos
        }
    }

    protected override void OnTriggerEnter2D(Collider2D c)
    {
        switch (c.tag) {
            case "Elixer":
                this.__power += c.GetComponent<Elixer>().__power;
                break;
            case "Block":
                this.__power -= c.GetComponent<Block>().__power;
                break;
            default:
                string msg = "Invalid base object is entered";
                throw new System.Exception(msg);
        }
        Debug.Log("Current power is " + __power.ToString());

        if (__power <= 0)
        {
            Destroy(gameObject);
            gameController.OverGame();
        }
    }
}