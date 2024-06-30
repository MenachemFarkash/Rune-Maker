using UnityEngine;

public class QuestManager : MonoBehaviour {

    #region Singleton
    public static QuestManager instance;

    private void Awake() {
        instance = this;
    }

    #endregion

    public Quest CurrentActiveQuest;
    public QuestTask CurrentActiveTask;

    public TaskType LastActionPerformed;



    public void CheckIfToProgressQuest(TaskType taskType) {
        if (CurrentActiveQuest = null) {
            return;
        }

        if (taskType == CurrentActiveTask.taskType) {
            switch (taskType) {
                case TaskType.TalkTo:

                    break;
                case TaskType.Gather:
                    CheckItemGathered();
                    break;
                case TaskType.Kill:
                    CheckEnemyKilled();
                    break;
                case TaskType.Craft:
                    break;
                case TaskType.Deliver:
                    CheckItemDelivered();
                    break;
                default:
                    break;
            }
        }

    }

    public void CheckNPCTalkedTo(TalkTask task, string npcId) {
        if (CurrentActiveQuest != null && npcId == task.NPCId) {
            ProgressQuest();
        }
    }

    public void CheckItemGathered() {

    }

    public void CheckEnemyKilled() {

    }

    public void CheckItemCrafted(CraftTask task, Item itemCrafted) {
        if (itemCrafted == task.itemToCraft) {
            ProgressQuest();
        }
    }

    public void CheckItemDelivered() {

    }

    public void StartQuest(Quest newQuest) {
        CurrentActiveQuest = newQuest;
        newQuest.CurrentActiveTask = newQuest.Tasks[0];
        newQuest.QuestProgress = 1;
        CurrentActiveTask = CurrentActiveQuest.Tasks[0];
    }

    public void ProgressQuest() {
        if (CurrentActiveQuest.QuestProgress != CurrentActiveQuest.Tasks.Count) {
            CurrentActiveQuest.MoveToNextTask();
            CurrentActiveTask = CurrentActiveQuest.CurrentActiveTask;
            QuestsUIManager.instance.UpdateTaskProgressUI();
        } else {
            FinishQuest(CurrentActiveQuest);
        }
    }

    public void FinishQuest(Quest quest) {
        quest.ChangeQuestState(QuestState.Completed);
    }
}
