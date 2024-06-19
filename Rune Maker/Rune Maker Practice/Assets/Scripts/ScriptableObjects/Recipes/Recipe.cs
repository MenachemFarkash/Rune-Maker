using UnityEngine;

public class Recipe : ScriptableObject {
    public Item[] resourcesRequired;
    public int levelRequierd;
    public Item ItemOutput;
    public ItemType itemType;
}
