using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int buyPrice;
    public int sellPrice;

    public ItemType type;

    public virtual void Use() {
        // Use the item

        Debug.Log("Using: " + name);
        Inventory.Instance.currentSelectedItem = this;
    }


    public void RemoveFromInventory() {
        Inventory.Instance.RemoveItem(this);
    }




}
