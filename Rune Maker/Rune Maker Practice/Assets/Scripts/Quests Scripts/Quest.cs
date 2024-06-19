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
        CurrentActiveTask = Tasks[QuestProgress + 1];
        QuestProgress++;
    }
}
