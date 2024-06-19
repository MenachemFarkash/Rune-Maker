
using UnityEngine;
using UnityEngine.UI;


public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    public Image healthBar;

    public Stat damage;
    public Stat armor;
    public Stat attackSpeed;

    private void Awake() {
        currentHealth = maxHealth;
    }



    public void TakeDamage(int damage) {

        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        currentHealth -= damage;
        print($"{transform.name} takes {damage} damage.");

        UpdateUI();

        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        // this method meant to be overwritten
        Debug.Log(transform.name + " Died.");
    }

    public void Heal(int healAmount) {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateUI();
        print("Player Healed: " + healAmount);
    }

    public void UpdateUI() {
        float healthValue = ((float)(currentHealth - 1) / (maxHealth - 1)) * (1 - 0.1f) + 0.1f;
        healthBar.rectTransform.localScale = new Vector3(1, healthValue, 1);
    }
}


