using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public LayerMask movementMask;
    public LayerMask playerLayerMask;
    public NavMeshAgent agent;
    public Camera cam;

    public Interactable focus;

    public Transform target;

    public PlayerMotor motor;



    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

        if (SceneManager.GetActiveScene().buildIndex == 1) {
            transform.position = new Vector3(55, 78.5f, 50);
        }
    }

    // Update is called once per frame
    void Update() {

        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        //if (Input.GetMouseButtonDown(0)) {
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100f, movementMask)) {
        //        RemoveFocus();
        //        motor.MoveToPoint(hit.point);
        //    }
        //}

        //if (Input.GetMouseButtonDown(1)) {
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100f, ~playerLayerMask)) {
        //        Interactable interactable = hit.collider.GetComponent<Interactable>();
        //        if (interactable != null) {
        //            SetFocus(interactable);
        //        }
        //    }
        //}

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, movementMask)) {
                RemoveFocus();
                motor.MoveToPoint(hit.point);
            }

            if (Physics.Raycast(ray, out hit, 100f, ~playerLayerMask)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) {
                    SetFocus(interactable);
                }
            }


        }

        if (Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


        }
    }

    void SetFocus(Interactable newFocus) {
        if (newFocus != focus) {
            if (focus != null) {

                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus() {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }

    public void TeleportTo(Transform teleportTarget) {
        motor.target = teleportTarget;
        agent.Warp(teleportTarget.position);
    }
}
