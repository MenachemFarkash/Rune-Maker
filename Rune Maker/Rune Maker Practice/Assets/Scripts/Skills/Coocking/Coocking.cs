using UnityEngine;

public class Coocking : Interactable {
    public RawFood selectedFood;
    public override void Interact() {
        base.Interact();

        if (Inventory.Instance.currentSelectedItem != null && Inventory.Instance.currentSelectedItem.type == ItemType.RawFood) {
            selectedFood = (RawFood)Inventory.Instance.currentSelectedItem;
            Cook();
        }
    }

    public void Cook() {
        float x = Random.Range(0, 100);
        if (x >= selectedFood.cookChance) {
            Inventory.Instance.RemoveItem(Inventory.Instance.currentSelectedItem);
            Inventory.Instance.AddItem(selectedFood.foodOutput);
            Inventory.Instance.currentSelectedItem = null;
        }
    }
}