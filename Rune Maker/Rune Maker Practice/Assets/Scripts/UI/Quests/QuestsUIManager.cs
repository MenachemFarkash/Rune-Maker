using TMPro;
using UnityEngine;

public class QuestsUIManager : MonoBehaviour {

    public Quest currentOpenQuest;

    public GameObject questsListUI;


    // Quest Info Things

    public GameObject QuestInfoUI;

    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questRequirments;


    public void OpenAndCloseQuestsList() {
        questsListUI.SetActive(!questsListUI.activeSelf);
    }

    public void UpdateUI() {
        questTitle.text = currentOpenQuest.QuestName;
        questDescription.text = currentOpenQuest.QuestDescription;
        questRequirments.text = currentOpenQuest.QuestRequirements;
    }

    public void OpenQuestInfo(Quest quest) {
        currentOpenQuest = quest;
        if (!QuestInfoUI.activeSelf) {
            CloseAndOpenQuestInfo();
            UpdateUI();
        } else {
            UpdateUI();
        }
    }

    public void CloseAndOpenQuestInfo() {
        QuestInfoUI.SetActive(!QuestInfoUI.activeSelf);
    }

    public void StartQuest() {
        QuestManager.instance.StartQuest(currentOpenQuest);
    }





}
