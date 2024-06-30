using UnityEngine;

public class Shop : Interactable {
    public GameObject ShopUIGameObject;
    public ShopItems ShopItems;


    public override void Interact() {
        base.Interact();

        ShopUIGameObject.SetActive(true);
        ShopUi.instance.ShopItems = ShopItems;
        ShopUi.instance.OpenShop();
    }
}
