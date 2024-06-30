public class NPC : Interactable {
    public string NPCName;
    public string npcId;
    public DialogueTrigger trigger;

    public Interactable proffesion;


    private void Start() {
        NPCManager.instance.RegisterNPC(npcId, this);
    }

    public override void Interact() {
        base.Interact();
        DialogueManager.instance.NPCTalkedTo = this;
        trigger.TriggerDialogue();
    }

    public void OpenProffesion() {
        proffesion.Interact();
    }
}
