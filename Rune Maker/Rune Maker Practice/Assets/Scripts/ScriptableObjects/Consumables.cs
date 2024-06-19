using UnityEngine;


public class Consumables : Item {
    public override void Use() {
        base.Use();

        Debug.Log("Consumable Consumed");

        //Add health to the player

    }
}
