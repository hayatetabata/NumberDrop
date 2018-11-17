using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBest : MonoBehaviour {

    int __highScore = 0;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("highScore")) {
            __highScore = PlayerPrefs.GetInt("highScore");
        }

        int score = PlayerPrefs.GetInt("score");
        if (__highScore < score) {
            PlayerPrefs.SetInt("highScore", score);
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
}
