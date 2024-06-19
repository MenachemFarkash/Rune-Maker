using UnityEngine;
using UnityEngine.UI;


public class SmeltingUI : MonoBehaviour {



    public Recipe currentActiveRecipe;

    Inventory inventory;

    public GameObject UIMenu;

    public Button closeButton;

    int tempResourceCount = 0;

    void Start() {
        inventory = Inventory.Instance;
        closeButton.onClick.AddListener(CloseMenu);
    }


    public void Craft() {
        if (currentActiveRecipe != null) {

            if (currentActiveRecipe.resourcesRequired.Length > 1) {
                for (int i = 0; i < currentActiveRecipe.resourcesRequired.Length; i++) {
                    if (inventory.items.Contains(currentActiveRecipe.resourcesRequired[i])) {
                        tempResourceCount++;
                    }
                }


                if (tempResourceCount == currentActiveRecipe.resourcesRequired.Length) {
                    for (int i = 0; i < currentActiveRecipe.resourcesRequired.Length; i++) {
                        if (inventory.items.Contains(currentActiveRecipe.resourcesRequired[i])) {
                            inventory.items.Remove(currentActiveRecipe.resourcesRequired[i]);
                        }
                    }
                    inventory.AddItem(currentActiveRecipe.ItemOutput);
                    tempResourceCount = 0;
                }
            }

        }
    }

    public void SetActiveRecipe(BarRecipe newBarRecipe) {
        if (currentActiveRecipe != newBarRecipe) {
            currentActiveRecipe = newBarRecipe;
        }
    }

    public void CloseMenu() {
        UIMenu.SetActive(!UIMenu.activeSelf);
    }


}
