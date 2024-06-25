public class NPC : Interactable {
    public string NPCName;
    public DialogueTrigger trigger;

    public Interactable proffesion;

    public override void Interact() {
        base.Interact();
        DialogueManager.instance.NPCTalkedTo = this;
        trigger.TriggerDialogue();


    }

    public void OpenProffesion() {
        proffesion.Interact();
    }
}
