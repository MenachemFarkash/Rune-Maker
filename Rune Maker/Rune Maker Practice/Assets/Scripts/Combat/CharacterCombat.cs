using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    private float attackCooldown = 0f;

    public float attckDelay = .6f;

    private CharacterStats myStats;

    public event System.Action OnAttack;

    private void Start() {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update() {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats) {
        if (attackCooldown <= 0f) {

            StartCoroutine(DoDamage(targetStats, attckDelay));
            attackCooldown = 1f / myStats.attackSpeed.GetValue();

            if (OnAttack != null) {
                OnAttack();
            }
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay) {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());

    }
}
