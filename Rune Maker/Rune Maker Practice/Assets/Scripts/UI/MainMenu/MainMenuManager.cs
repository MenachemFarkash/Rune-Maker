using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void CloseGame() {
        Application.Quit();
    }

    public void OpenSettings() {

    }
}
