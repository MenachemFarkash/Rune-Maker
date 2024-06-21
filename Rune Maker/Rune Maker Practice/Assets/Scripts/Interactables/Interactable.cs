using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = 3f;

    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;



    public virtual void Interact() {


        print("interacting with: " + name);


    }




    private void Update() {
        if (isFocus && !hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance < radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerPosition) {
        isFocus = true;
        player = playerPosition;
        hasInteracted = false;

    }

    public void OnDefocused() {
        PlayerAnimator.Instance.ChangeAnimationState(PlayerAnimationState.PLAYER_IDLE);

        hasInteracted = false;
        isFocus = false;
        player = null;
    }

    private void OnDrawGizmosSelected() {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
