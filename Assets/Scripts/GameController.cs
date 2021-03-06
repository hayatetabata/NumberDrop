﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Canvas modal;
    public Canvas score;
    public UnityAdsController adsController;

    int __respawn_count = 0;
    int __score = 0;
    const int __max_respawn_count = 3;
    const string __player_prefs_key = "respawn_count";

    public void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        __respawn_count = PlayerPrefs.GetInt(__player_prefs_key);
        score.gameObject.SetActive(true);
    }

    public void ReStartGame()
    {
        __respawn_count += 1;
        if (__respawn_count >= __max_respawn_count) {
            adsController.ShowAd();
            Reset();
            SceneManager.LoadScene("HomeScene");
            return;
        }

        PlayerPrefs.SetInt(__player_prefs_key, __respawn_count);
        SceneManager.LoadScene("GameScene");
    }

    public void OverGame()
    {
        StopAllObjects();
        if (IsHighScore(__score)) {
            PlayerPrefs.SetInt("highScore", __score);
        }

        score.gameObject.SetActive(false);
        modal.gameObject.SetActive(true);
    }

    void Reset()
    {
        __respawn_count = 0;
        PlayerPrefs.SetInt(__player_prefs_key, __respawn_count);
    }

    void StopAllObjects()
    {
        FindObjectOfType<WaveGenerator>().__generatable = false;

        string[] tags = {"Elixer", "Block"};
        foreach (string tagName in tags) {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tagName);
            foreach (GameObject obj in objects) {
                obj.GetComponent<BaseObject>().__speed = 0f;
            }
        }
    }

    bool IsHighScore(int score) {
        int highScore = 0;
        if (PlayerPrefs.HasKey("highScore")) {
            highScore = PlayerPrefs.GetInt("highScore");
        }

        return score > highScore;
    }

    public void SetScore(int score) {
        __score = score;
    }
}
