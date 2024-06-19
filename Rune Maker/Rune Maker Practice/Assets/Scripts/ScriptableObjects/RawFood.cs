using UnityEngine;

[CreateAssetMenu(fileName = "Raw Food", menuName = "Consumables/Raw Food")]
public class RawFood : Consumables {

    public float cookChance;
    public Food foodOutput;
    public override void Use() {
        base.Use();


    }
}
