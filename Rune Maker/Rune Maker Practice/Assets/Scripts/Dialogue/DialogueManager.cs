using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    #region Singleton

    public static DialogueManager instance;

    private void Awake() {
        instance = this;
    }

    #endregion

    //UI Refrences
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private TextMeshProUGUI dialogueNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image NPCFace;

    public NPC NPCTalkedTo;

    private Queue<string> sentences;

    private void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        print("Starting conversation with " + dialogue.name);
        dialogueBox.SetActive(true);


        dialogueNameText.text = dialogue.name;
        NPCFace.sprite = dialogue.Image;

        sentences.Clear();


        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(2 * Time.deltaTime);
        }
    }



    public void EndDialogue() {
        print("End Of Conversation");
        if (NPCTalkedTo != null) {
            QuestManager.instance.CheckNPCTalkedTo((TalkTask)QuestManager.instance.CurrentActiveTask, NPCTalkedTo.npcId);
        }
        NPCTalkedTo.OpenProffesion();
        dialogueBox.SetActive(false);
    }
}
