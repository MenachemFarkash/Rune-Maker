using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour {
    public NavMeshAgent agent;

    public Transform target;

    private void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update () {
        if (target != null) {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
    public void MoveToPoint ( Vector3 target ) {
        agent.SetDestination(target);
    }

    public void FollowTarget ( Interactable targetToFollow ) {
        agent.stoppingDistance = targetToFollow.radius * 0.8f;
        agent.updateRotation = false;

        target = targetToFollow.interactionTransform;
    }

    public void StopFollowingTarget () {
        agent.updateRotation = true;

        agent.stoppingDistance = 0;
        target = null;
    }

    public void FaceTarget () {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
