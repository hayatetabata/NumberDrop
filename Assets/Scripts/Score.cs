using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int __score = 0;
    public bool __show_best = false;
    Text __score_text;
    const string suffix = "pts";

	// Use this for initialization
	void Start () {
        __score_text = GetComponent<Text>();

        string key = __show_best ? "highScore" : "score";
        if (PlayerPrefs.HasKey(key)) {
            __score = PlayerPrefs.GetInt(key);
        }
	}
	
	// Update is called once per frame
	void Update () {
        string key = __show_best ? "highScore" : "score";
        __score = PlayerPrefs.GetInt(key);
        __score_text.text = __score.ToString() + suffix;
    }
}
