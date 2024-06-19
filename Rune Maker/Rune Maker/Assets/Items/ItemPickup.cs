using UnityEngine;
using static UnityEditor.Progress;

public class ItemPickup : Interactable {

    public Item item;

    public override void Interact() {
        base.Interact();

        Pickup();
    }

    public void Pickup() {



        Debug.Log($"Picking up {item.name}");


        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp) {

            Destroy(gameObject);
        }
    }

}
