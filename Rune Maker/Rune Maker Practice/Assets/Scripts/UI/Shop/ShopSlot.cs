using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour {

    public Item item;

    #region ui

    public Image iconImage;
    public TextMeshProUGUI nameText;
    public Button SetActiveButton;


    #endregion

    private void Start() {

        SetActiveButton.onClick.AddListener(SetActive);
        iconImage.sprite = item.icon;
        nameText.text = item.name;
    }

    public void SetActive() {
        ShopUi.instance.SetActiveShopItem(this);
    }
}
