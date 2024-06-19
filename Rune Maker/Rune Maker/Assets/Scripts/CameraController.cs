using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    // Zoom variables:
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    // pitch is the amount the camera needs to aim upwrads in order to look at the player properaly
    // the player is 2 units tall, and so the pitch.
    public float pitch = 2f;

    // camera rotation speed:
    public float yawSpeed = 100f;

    //private variable
    // straight forward
    private float currentZoom = 10f;
    private float currentYaw = 0f;



    private void Update() {
        // control the zoom of the camera
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        //control the rotation of the camera around the player
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate() {
        //transform the position of the camera to follow the player
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        //transform the rotation of the camera from the player Horizontal input
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
