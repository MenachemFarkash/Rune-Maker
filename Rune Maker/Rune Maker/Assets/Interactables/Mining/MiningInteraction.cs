public class MiningInteraction : Interactable {
    public Item item;
    public override void Interact() {
        base.Interact();

        Mine();
    }

    public void Mine() {
        print($"Mining ore: {item.name}");
    }
}
