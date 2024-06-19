using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Consumables/Food")]
public class Food : Consumables {
    public int hitPointsHeal;

    public override void Use() {
        base.Use();


        PlayerStats.Instance.Heal(hitPointsHeal);
        Debug.Log("Consumable " + name + " Consumed");
        Inventory.Instance.RemoveItem(this);

    }
}
