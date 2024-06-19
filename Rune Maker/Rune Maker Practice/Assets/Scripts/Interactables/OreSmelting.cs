using UnityEngine;

public class OreSmelting : Interactable {

    public GameObject ui;

    public override void Interact() {
        base.Interact();

        ui.SetActive(!ui.activeSelf);
        CraftingManager.instance.UIMenu = ui;
    }

}
