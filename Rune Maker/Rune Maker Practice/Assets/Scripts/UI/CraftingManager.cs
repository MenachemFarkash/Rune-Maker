using UnityEngine;


public class CraftingManager : MonoBehaviour {

    #region Singleton

    public static CraftingManager instance;
    private void Awake() {
        instance = this;
    }

    #endregion

    public Recipe currentActiveRecipe;

    Inventory inventory;

    public GameObject UIMenu;

    int tempResourceCount = 0;

    void Start() {
        inventory = Inventory.Instance;
    }


    public void Craft() {
        if (currentActiveRecipe != null) {

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
                if (QuestManager.instance.CurrentActiveTask.taskType == TaskType.Craft && QuestManager.instance.CurrentActiveTask != null) {
                    QuestManager.instance.CheckItemCrafted((CraftTask)QuestManager.instance.CurrentActiveTask, currentActiveRecipe.ItemOutput);
                }
                tempResourceCount = 0;


                switch (currentActiveRecipe.itemType) {
                    case ItemType.Equipment:
                        SkillsManager.instance.SkillList[1].AddXP(4);
                        break;
                    case ItemType.Bar:
                        SkillsManager.instance.SkillList[1].AddXP(4);
                        break;
                }
            }

        }
    }

    public void SetActiveRecipe(Recipe newRecipe) {
        if (currentActiveRecipe != newRecipe) {
            currentActiveRecipe = newRecipe;
        }
    }

    public void CloseUIMenu() {
        if (UIMenu != null) {
            UIMenu.SetActive(false);
            UIMenu = null;
        }
    }


}

