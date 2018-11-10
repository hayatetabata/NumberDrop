using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Canvas modal;
    public Canvas score;

    int __respawn_count = 0;
    const int __max_respawn_count = 3;
    const string __player_prefs_key = "respawn_count";

    public void Start()
    {
        __respawn_count = PlayerPrefs.GetInt(__player_prefs_key);
        score.gameObject.SetActive(true);
    }

    public void ReStartGame()
    {
        __respawn_count += 1;
        if (__respawn_count >= __max_respawn_count) {
            //Show Ads
            Reset();
        } else {
            PlayerPrefs.SetInt(__player_prefs_key, __respawn_count);
        }
        SceneManager.LoadScene("GameScene");
    }

    public void OverGame()
    {
        StopGenerators();
        StopAllObjects();

        score.gameObject.SetActive(false);
        modal.gameObject.SetActive(true);
    }

    void Reset()
    {
        __respawn_count = 0;
        PlayerPrefs.SetInt(__player_prefs_key, __respawn_count);
    }

    void StopGenerators()
    {
        GameObject[] generators = GameObject.FindGameObjectsWithTag("Generator");
        foreach (GameObject generator in generators) {
            generator.GetComponent<BaseObjectGenerator>().__generatable = false;
        }
    }

    void StopAllObjects()
    {
        string[] tags = {"Elixer", "Block"};
        foreach (string tagName in tags) {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tagName);
            foreach (GameObject obj in objects) {
                obj.GetComponent<BaseObject>().__speed = 0f;
            }
        }
    }
}
