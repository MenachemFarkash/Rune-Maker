using UnityEngine;

public class MiniMapCameraEngine : MonoBehaviour {

    private Transform player;
    // Start is called before the first frame update
    void Start() {
        player = PlayerManager.Instance.player.transform;
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(player.position.x, 100, player.position.z);
    }
}
