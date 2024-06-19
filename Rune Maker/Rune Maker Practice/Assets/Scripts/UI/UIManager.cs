using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject SkillsMenu;
    public GameObject questsUI;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            OpenSkillsMenu();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            OpenQuestsList();
        }
    }

    public void OpenSkillsMenu() {
        SkillsMenu.SetActive(!SkillsMenu.activeSelf);

    }

    public void OpenQuestsList() {
        questsUI.SetActive(!questsUI.activeSelf);
    }
}
