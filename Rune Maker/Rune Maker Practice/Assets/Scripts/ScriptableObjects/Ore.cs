using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Mining/Ores")]
public class Ore : Item {

    public OreType Type;
    public float Health;

}

public enum OreType { Iron, Copper, Tin, Gold, Daeyalt, Coal }
