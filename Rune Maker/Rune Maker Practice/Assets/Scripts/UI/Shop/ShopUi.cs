using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUi : MonoBehaviour {

    #region Singleton

    public static ShopUi instance;

    private void Awake() {
        instance = this;
    }

    #endregion


    public ShopItems ShopItems;
    public ShopSlot activeShopItem;
    public Transform shopItemsContainer;
    public GameObject shopSlotPrefab;

    public Image infoIcon;
    public TextMeshProUGUI infoItemName;
    public TextMeshProUGUI infoItemPrice;
    public TextMeshProUGUI infoItemDescription;

    public InventoryUI inventoryUI;






    public void UpdateUI() {



        if (activeShopItem != null) {
            infoIcon.sprite = activeShopItem.item.icon;
            infoItemName.text = activeShopItem.item.name;
            infoItemPrice.text = activeShopItem.item.buyPrice.ToString();
        }
    }

    public void SetActiveShopItem(ShopSlot shopItem) {

        activeShopItem = shopItem;

        UpdateUI();
    }

    public void BuyItem() {
        if (inventoryUI.gold >= activeShopItem.item.buyPrice) {
            Inventory.Instance.AddItem(activeShopItem.item);
            inventoryUI.gold -= activeShopItem.item.buyPrice;
        }
    }

    public void SellItem() {
        if (Inventory.Instance.items.Contains(activeShopItem.item)) {
            Inventory.Instance.RemoveItem(activeShopItem.item);
            inventoryUI.gold += activeShopItem.item.sellPrice;
        }
    }

    public void OpenShop() {
        foreach (Item item in ShopItems.shopItems) {
            GameObject instantiatedItem = Instantiate(shopSlotPrefab, shopItemsContainer);
            instantiatedItem.GetComponent<ShopSlot>().item = item;
        }

        activeShopItem = null;

        UpdateUI();
    }

    public void CloseShop() {
        gameObject.SetActive(false);

        foreach (RectTransform child in shopItemsContainer) {
            Destroy(child.gameObject);
        }
    }


}
