using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager instance;

    private void Awake() {
        instance = this;
    }

    public Quest CurrentActiveQuest;


    // Quest UI Elements





    public void StartQuest(Quest newQuest) {
        CurrentActiveQuest = newQuest;
        print("New Quest Started");
    }
}
