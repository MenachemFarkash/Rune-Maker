using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour {

    public static Inventory instance;

    #region Singleton
    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item) {
        if (!item.isDefaultItem) {
            if (items.Count >= space) {
                print("Cant carry any more");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallback != null) {

                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item) {
        items.Remove(item);

        if (onItemChangedCallback != null) {

            onItemChangedCallback.Invoke();
        }
    }
}
