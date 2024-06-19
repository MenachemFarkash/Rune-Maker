using UnityEngine;

public class Woodcutting : Interactable {

    public TreeType treeType;
    public Tree treeOutput;

    public float choppingProgress;

    public override void Interact() {
        base.Interact();

        InvokeRepeating(nameof(ChopDownTree), 0, 1);

    }

    void AddToInventory() {
        Debug.Log("Successfuly extracted: " + treeOutput);
        Inventory.Instance.AddItem(treeOutput);
    }

    public void ChopDownTree() {
        print("Chopping: " + treeType);

        choppingProgress += Random.Range(20, 50);

        if (choppingProgress >= treeOutput.health) {

            StopChopping();
            AddToInventory();
            choppingProgress = 0f;
        }
    }

    public void StopChopping() {
        CancelInvoke();
        //PlayerAnimator.Instance.ChangeAnimationState(PlayerAnimationState.PLAYER_IDLE);
    }

}

public enum TreeType {
    Tree,
    Oak,
    Willow,
    Teak,
    Maple,
    Mahogany,
    Yew
}
