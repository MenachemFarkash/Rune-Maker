using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDisOnLoad : MonoBehaviour {
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            SceneManager.LoadScene(1);
        }
    }
}
