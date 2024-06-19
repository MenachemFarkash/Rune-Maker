using UnityEngine;

public class PlayerStats : CharacterStats {

    #region Singleton
    public static PlayerStats Instance;

    private void Awake() {
        Instance = this;
    }

    #endregion


    // Start is called before the first frame update
    void Start() {
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
        currentHealth = maxHealth;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(5);
        }
    }



    void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {
        if (newItem != null) {

            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null) {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die() {
        base.Die();
        PlayerManager.Instance.KillPlayer();
        // Kill the player
    }
}
