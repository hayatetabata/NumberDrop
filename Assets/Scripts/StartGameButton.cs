using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {

    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
