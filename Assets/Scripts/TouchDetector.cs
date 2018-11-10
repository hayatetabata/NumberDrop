using UnityEngine;

public static class TouchDetector
{
    public static string Detect()
    {
        if (IsEventType(TouchEventKeys.IsTouched)) {
            return TouchEventKeys.IsTouched;
        }
        if (IsEventType(TouchEventKeys.WasTouched)) {
            return TouchEventKeys.WasTouched;
        }
        return TouchEventKeys.NotTouched;

    }

    public static Vector2 GetTouchPosition()
    {
        if (Application.isEditor) {
            return Input.mousePosition;
        } else {
            if (Input.touchCount > 0) {
                return Input.GetTouch(0).position;
            }
            throw new System.Exception("The finger or cursor are not attaching now.");
        }
    }

    public static bool IsEventType(string eventName)
    {
        if (Application.isEditor)
        {
            switch (eventName)
            {
                case TouchEventKeys.WasTouched:
                    return Input.GetMouseButtonDown(0);
                case TouchEventKeys.IsTouched:
                    return Input.GetMouseButton(0);
                default:
                    throw new System.Exception("Invalid argument " + eventName);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (eventName)
                {
                    case TouchEventKeys.WasTouched:
                        return touch.phase == TouchPhase.Began;
                    case TouchEventKeys.IsTouched:
                        return touch.phase == TouchPhase.Moved;
                    default:
                        throw new System.Exception("Invalid argument " + eventName);
                }
            }
        }
        return false;
    }
}

public class TouchEventKeys {
    public const string WasTouched = "WasTouched";
    public const string IsTouched = "IsTouched";
    public const string NotTouched = "NotTouched";
}