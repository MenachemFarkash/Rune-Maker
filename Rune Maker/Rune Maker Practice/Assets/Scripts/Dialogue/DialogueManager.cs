using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    #region Singleton

    public static DialogueManager instance;

    private void Awake() {
        instance = this;
    }

    #endregion

    private Queue<string> sentences;

    private void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {

    }
}
