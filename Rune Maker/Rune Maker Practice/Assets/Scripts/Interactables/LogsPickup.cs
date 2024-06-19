using UnityEngine;

public class LogsPickup : ItemPickup {
    public Transform targetLogs;

    public GameObject logsFire;
    public override void Interact() {
        if (Inventory.Instance.currentSelectedItem != null && Inventory.Instance.currentSelectedItem.type == ItemType.Tinderbox) {

            CreateFire();

        } else {
            base.Interact();
            print("base Intercation");
        }

    }

    public void CreateFire() {
        print("Creating Fire");
        targetLogs = gameObject.transform;
        Instantiate(logsFire, targetLogs.transform.position, Quaternion.identity);
        Destroy(targetLogs.gameObject);
        Inventory.Instance.currentSelectedItem = null;

    }
}
