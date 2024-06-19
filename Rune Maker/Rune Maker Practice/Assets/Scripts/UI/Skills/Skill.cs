using TMPro;
using UnityEngine;

public class Skill : MonoBehaviour {

    #region Fields
    public string skillName;
    public int level = 1;
    public float currentXP;
    public float nextLevelXPTarget;

    #endregion

    #region UI

    public TextMeshProUGUI levelText;

    #endregion


    public float[] levelsXPRequired = new float[] {
        6,
        174,
        276,
        388,
        512,
        650,
        801,
        969,
        1154
    };

    public void LevelUp() {
        if (currentXP >= levelsXPRequired[level]) {
            print("Level Should Be UP");
            level++;
            SkillsManager.instance.UpdateUI();

        }
    }

    public int GetLevel() {
        return level;
    }

    public float GetXP() {
        return currentXP;
    }

    public void AddXP(int xpAmount) {
        currentXP += xpAmount;
        SkillsManager.instance.UpdateUI();
    }

    private void Update() {
        if (currentXP >= levelsXPRequired[level]) {
            LevelUp();
        }
    }

}
