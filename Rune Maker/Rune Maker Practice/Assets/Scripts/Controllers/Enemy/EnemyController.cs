using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public float lookRadius = 10f;

    Transform target;

    NavMeshAgent agent;

    CharacterCombat combat;
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.Instance.player.transform;
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance) {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null) {
                    combat.Attack(targetStats);
                }

                FaceTarget();
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
