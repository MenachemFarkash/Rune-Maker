using UnityEngine;
using UnityEngine.UI;


public class SmithingUI : MonoBehaviour {

    #region Singleton
    public static SmithingUI instance;

    private void Awake() {
        instance = this;
    }

    #endregion



    public Recipe currentActiveRecipe;

    Inventory inventory;

    public GameObject smeltingScreen;

    public Button closeButton;

    int tempOresCount = 0;

    void Start() {
        inventory = Inventory.Instance;
    }


    public void Smelt() {
        if (currentActiveRecipe != null) {

            if (currentActiveRecipe.resourcesRequired.Length > 1) {
                for (int i = 0; i < currentActiveRecipe.resourcesRequired.Length; i++) {
                    if (inventory.items.Contains(currentActiveRecipe.resourcesRequired[i])) {
                        tempOresCount++;
                    }
                }

                print(tempOresCount);

                if (tempOresCount == currentActiveRecipe.resourcesRequired.Length) {
                    for (int i = 0; i < currentActiveRecipe.resourcesRequired.Length; i++) {
                        if (inventory.items.Contains(currentActiveRecipe.resourcesRequired[i])) {
                            inventory.items.Remove(currentActiveRecipe.resourcesRequired[i]);
                        }
                    }
                    inventory.AddItem(currentActiveRecipe.ItemOutput);
                    tempOresCount = 0;
                }
            }

        }
    }

    public void SetActiveRecipe(Recipe newBarRecipe) {
        if (currentActiveRecipe != newBarRecipe) {
            currentActiveRecipe = newBarRecipe;
        }
    }

    public void CloseSmithingMenu() {
        smeltingScreen.SetActive(!smeltingScreen.activeSelf);
    }


}
