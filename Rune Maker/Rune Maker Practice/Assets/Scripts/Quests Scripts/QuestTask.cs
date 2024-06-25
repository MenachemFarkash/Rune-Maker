using UnityEngine;

public class QuestTask : ScriptableObject {
    public TaskType taskType;
    [TextArea(3, 10)]
    public string taskDescription;
}

[CreateAssetMenu(fileName = "TalkTask", menuName = "Quests/Tasks/Talk Task")]
public class TalkTask : QuestTask {
    public NPC Npc;
}

[CreateAssetMenu(fileName = "GatherTask", menuName = "Quests/Tasks/Gather Task")]
public class GatherTask : QuestTask {
    public Item[] itemsToGather;
}

[CreateAssetMenu(fileName = "KillTask", menuName = "Quests/Tasks/Kill Task")]
public class KillTask : QuestTask {
    public string enemyName;
    public int amountToKill;
}

[CreateAssetMenu(fileName = "CraftTask", menuName = "Quests/Tasks/Craft Task")]
public class CraftTask : QuestTask {
    public Item itemToCraft;
    public int amountToCraft;
}

[CreateAssetMenu(fileName = "FindTask", menuName = "Quests/Tasks/Find Task")]
public class FindTask : QuestTask {
    public Item itemToFind;
    public int amountToFind;
}

[CreateAssetMenu(fileName = "DeliverTask", menuName = "Quests/Tasks/Deliver Task")]
public class DeliverTask : QuestTask {
    public Item[] itemsToDeliver;
}
