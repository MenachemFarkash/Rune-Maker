using UnityEngine;

[CreateAssetMenu(fileName = "New Tree", menuName = "Woodcutting/Tree")]

public class Tree : Item {
    public LogsType logType;
    public float health;
    public GameObject logsFire;


    public override void Use() {
        if (Inventory.Instance.currentSelectedItem != null && Inventory.Instance.currentSelectedItem.type == ItemType.Tinderbox) {
            CreateFire();
        } else {
            base.Use();
        }


    }

    public void CreateFire() {
        Transform targetLogs = PlayerManager.Instance.player.transform;
        Instantiate(logsFire, targetLogs.transform.position, Quaternion.identity);
        Inventory.Instance.RemoveItem(this);
        Inventory.Instance.currentSelectedItem = null;
    }
}

public enum LogsType {
    Tree,
    Oak,
    Willow,
    Teak,
    Maple,
    Mahogany,
    Yew
}
