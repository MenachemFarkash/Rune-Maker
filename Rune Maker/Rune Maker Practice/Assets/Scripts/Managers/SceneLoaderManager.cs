using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour {

    public Vector3 scene1TargetPosition;
    private void OnEnable() {
        SceneManager.sceneLoaded += SceneLoaded; //You add your method to the delegate
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == 1) //use your desired check here to compare your scene
            PlayerManager.Instance.player.transform.position = scene1TargetPosition;
    }
}
