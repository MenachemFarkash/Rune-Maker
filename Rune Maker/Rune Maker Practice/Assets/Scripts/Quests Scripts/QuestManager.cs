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
                    CheckNPCTalkedTo();
                    break;
                case TaskType.Gather:
                    CheckItemGathered();
                    break;
                case TaskType.Kill:
                    CheckEnemyKilled();
                    break;
                case TaskType.Craft:
                    CheckItemCrafted();
                    break;
                case TaskType.Deliver:
                    CheckItemDelivered();
                    break;
                default:
                    break;
            }
        }

    }

    public void CheckNPCTalkedTo() {

    }

    public void CheckItemGathered() {

    }

    public void CheckEnemyKilled() {

    }

    public void CheckItemCrafted() {

    }

    public void CheckItemDelivered() {

    }

    public void StartQuest(Quest newQuest) {
        CurrentActiveQuest = newQuest;
        print("New Quest Started");
    }
}
