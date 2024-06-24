using UnityEngine;

public class Enums : MonoBehaviour {

}

public enum ItemType {
    Ore,
    Equipment,
    Log,
    Bar,
    RawFood,
    Tinderbox
}

public enum QuestState {
    Off,
    InProgress,
    Completed
}

public enum TaskType {
    TalkTo,
    Gather,
    Kill,
    Craft,
    Deliver
}