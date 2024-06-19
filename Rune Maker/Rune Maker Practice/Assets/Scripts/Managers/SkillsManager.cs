using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour {

    #region Singleton
    public static SkillsManager instance;

    private void Awake() {
        instance = this;
    }

    #endregion


    public List<Skill> SkillList;

    public GameObject SkillsParent;



    public void Start() {
        SkillList = new List<Skill>();
        foreach (Skill skill in SkillsParent.GetComponentsInChildren<Skill>()) {
            SkillList.Add(skill);
        }

        UpdateUI();
    }

    public void UpdateUI() {
        foreach (Skill skill in SkillList) {
            skill.levelText.text = $"LEVEL: {skill.level}/99\nXP: {skill.currentXP}/{skill.levelsXPRequired[skill.level]}";
        }
    }
}
