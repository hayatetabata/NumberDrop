using UnityEngine;
using UnityEngine.UI;

public class Player : BaseObject {

    public Text __number_text;
    public GameController gameController;

    Vector2 __touch_src;
    float __mix_x;
    float __max_x;

    // Initialize properties
    void Start()
    {
        //TODO
        //Specify both minX and maxX coodinate by screen width and player radius
        __mix_x = -3f;
        __max_x = 3f;
    }

    // Update is called once per frame
    void Update () {
        __number_text.text = __power.ToString();

        Vector3 scale = transform.localScale;
        scale.x = scale.y = __power * 1.5f;
        transform.localScale = scale;
        

        if (Camera.main.transform.position.y < transform.position.y) {
            Vector2 dist = new Vector2(0f, -1f);
            Move(dist, __speed);
        }
    }

    void FixedUpdate()
    {
        string touchType = TouchDetector.Detect();
        if (touchType == TouchEventKeys.IsTouched) {
            if (__touch_src == new Vector2()) {
                __touch_src = TouchDetector.GetTouchPosition();
            }
            Vector2 dist = TouchDetector.GetTouchPosition();
            float diff = ToScreenScale(dist.x - __touch_src.x);

            Vector2 newPos = transform.position;
            newPos.x += diff;
            transform.position = WithinScreen(newPos);

            __touch_src = dist;
        }
        if (touchType == TouchEventKeys.NotTouched) {
            __touch_src = new Vector2();
        }
    }

    float ToScreenScale(float src)
    {
        return src / 100;
    }

    Vector2 WithinScreen(Vector2 srcPos)
    {
        Vector2 distPos = new Vector2(
            Mathf.Clamp(srcPos.x, __mix_x, __max_x),
            srcPos.y
        );
        return distPos;
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