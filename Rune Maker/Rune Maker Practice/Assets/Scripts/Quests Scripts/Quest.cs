using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/New Quest")]
public class Quest : ScriptableObject {

    public List<QuestTask> Tasks = new List<QuestTask>();

    public QuestTask CurrentActiveTask;

    public int QuestProgress;

    public QuestState QuestCurrentState;

    // Quest Info:

    public string QuestName;
    public string QuestDescription;
    public string QuestRequirements;

    public void ChangeQuestState(QuestState newQuestState) {
        QuestCurrentState = newQuestState;
        Debug.Log("Quest State Changed");
    }

    public void MoveToNextTask() {
        if (QuestProgress + 1 > Tasks.Count) {
            QuestManager.instance.FinishQuest(this);
        } else {
            CurrentActiveTask = Tasks[QuestProgress];
            QuestProgress++;
        }
    }
}
