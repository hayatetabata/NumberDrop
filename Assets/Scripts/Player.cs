using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : BaseObject {

    public Text __number_text;
    public GameController gameController;

    Vector2 __touch_src;
    float __mix_x = -3f;
    float __max_x = 3f;
    int __score = 0;
    float __acceleration = 0.005f;

    // Update is called once per frame
    void Update () {
        __number_text.text = __power.ToString();

        Vector3 scale = transform.localScale;
        scale.x = scale.y = 0.2f + __power * 0.01f;
        transform.localScale = scale;

        Vector2 dist = new Vector2(0f, 1f);
        Move(dist, __speed);

        //Controll player
        string touchType = TouchDetector.Detect();
        if (touchType == TouchEventKeys.IsTouched) {
            if (__touch_src == new Vector2()) {
                __touch_src = TouchDetector.GetTouchPosition();
            }
            Vector2 touchDist = TouchDetector.GetTouchPosition();
            float diff = ToScreenScale(touchDist.x - __touch_src.x);

            Vector2 newPos = transform.position;
            newPos.x += diff;
            //transform.position = WithinScreen(newPos);
            transform.position = Vector3.Lerp(transform.position, WithinScreen(newPos), 0.8f);

            __touch_src = touchDist;
        }
        if (touchType == TouchEventKeys.NotTouched) {
            __touch_src = new Vector2();
        }

        __speed = Mathf.Clamp(__speed + __acceleration * Time.deltaTime, 0.01f, 0.1f);
    }

    float ToScreenScale(float src) {
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
                __power += c.GetComponent<Elixer>().__power;
                __score += __power;
                break;
            case "Block":
                __power -= c.GetComponent<Block>().__power;
                __score += __power;
                if (__score <= 0) { __score = 0; }
                break;
            default:
                string msg = "Invalid base object is entered";
                throw new System.Exception(msg);
        }

        if (__power <= 0) {
            Destroy(gameObject);
            gameController.OverGame();
        }
        UpdateScore(__score);
    }

    void UpdateScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }
}