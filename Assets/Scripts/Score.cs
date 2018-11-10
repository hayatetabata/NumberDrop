using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int __score = 0;
    Text __score_text;
    const string suffix = "pts";

	// Use this for initialization
	void Start () {
        __score_text = GetComponent<Text>();

        if (PlayerPrefs.HasKey("score")) {
            __score = PlayerPrefs.GetInt("score");
        }
	}
	
	// Update is called once per frame
	void Update () {
        __score = PlayerPrefs.GetInt("score");
        __score_text.text = __score.ToString() + suffix;
    }
}
