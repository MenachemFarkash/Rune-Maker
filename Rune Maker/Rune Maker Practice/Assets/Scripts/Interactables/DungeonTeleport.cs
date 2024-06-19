using UnityEngine;

public class DungeonTeleport : Interactable {

    public Transform dungeonTarget;

    public override void Interact() {
        base.Interact();

        PlayerManager.Instance.player.GetComponent<PlayerController>().TeleportTo(dungeonTarget);
    }

}
