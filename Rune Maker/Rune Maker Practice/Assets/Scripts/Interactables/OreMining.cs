using UnityEngine;

public class OreMining : Interactable {

    public OreNodeType oreType;
    public Ore oreOutput;
    public CharacterAnimator playerAnimator;
    public SkillsManager skillManager;

    private void Start() {
        playerAnimator = PlayerManager.Instance.player.GetComponent<CharacterAnimator>();
        skillManager = SkillsManager.instance;
    }

    private void LateUpdate() {
        if (PlayerAnimator.Instance.currentAnimation != PlayerAnimationState.PLAYER_MINING) {
            StopMining();
        }
    }

    public float miningProgress = 0f;

    public override void Interact() {
        base.Interact();

        InvokeRepeating(nameof(Mine), 0, 1);

    }

    void Mine() {
        PlayerAnimator.Instance.ChangeAnimationState(PlayerAnimationState.PLAYER_MINING);
        print("Mining: " + oreType);

        miningProgress += Random.Range(20, 50);

        if (miningProgress >= oreOutput.Health) {

            StopMining();
            AddToInventory();
            miningProgress = 0f;
            skillManager.SkillList[3].AddXP(4);

        }



    }

    public void StopMining() {
        CancelInvoke();
        PlayerAnimator.Instance.ChangeAnimationState(PlayerAnimationState.PLAYER_IDLE);
    }

    void AddToInventory() {
        Debug.Log("Successfuly extracted: " + oreOutput);
        Inventory.Instance.AddItem(oreOutput);


    }




}


public enum OreNodeType { Iron, Copper, Tin, Gold, Daeyalt, Coal }

