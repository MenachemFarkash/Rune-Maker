using TMPro;
using UnityEngine;

public class QuestsUIManager : MonoBehaviour {
    #region Singleton
    public static QuestsUIManager instance;

    private void Awake() {
        instance = this;
    }

    #endregion

    public Quest currentOpenQuest;

    public GameObject questsListUI;

    public QuestManager questManager;


    // Quest Info Things


    [Header("Quest Info")]
    public GameObject QuestInfoUI;

    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questRequirments;

    // Quest progress things
    [Header("Task Info")]
    public GameObject TaskInfoUI;

    public TextMeshProUGUI QuestProgressTitle;
    public TextMeshProUGUI taskProgressDescription;
    public TextMeshProUGUI TaskNumber;

    private void Start() {
        questManager = QuestManager.instance;
    }
    public void OpenAndCloseQuestsList() {
        questsListUI.SetActive(!questsListUI.activeSelf);
    }

    public void UpdateQuestInfoUI() {
        questTitle.text = currentOpenQuest.QuestName;
        questDescription.text = currentOpenQuest.QuestDescription;
        questRequirments.text = currentOpenQuest.QuestRequirements;
    }

    public void UpdateTaskProgressUI() {
        QuestProgressTitle.text = questManager.CurrentActiveQuest.QuestName;
        taskProgressDescription.text = questManager.CurrentActiveTask.taskDescription;
        TaskNumber.text = $"{questManager.CurrentActiveQuest.QuestProgress} / {questManager.CurrentActiveQuest.Tasks.Count}";
    }

    public void OpenQuestInfo(Quest quest) {
        currentOpenQuest = quest;
        if (!QuestInfoUI.activeSelf) {
            CloseAndOpenQuestInfo();
            UpdateQuestInfoUI();
        } else {
            UpdateQuestInfoUI();
        }
    }

    public void CloseAndOpenQuestInfo() {
        QuestInfoUI.SetActive(!QuestInfoUI.activeSelf);
    }
    public void CloseAndOpenTaskInfo() {
        TaskInfoUI.SetActive(!TaskInfoUI.activeSelf);
        UpdateTaskProgressUI();
    }

    public void StartQuest() {
        questManager.StartQuest(currentOpenQuest);
        UpdateTaskProgressUI();
    }





}
