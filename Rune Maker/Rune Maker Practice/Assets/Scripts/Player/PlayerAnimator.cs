public class PlayerAnimator : CharacterAnimator {

    #region Singleton

    public static PlayerAnimator Instance;

    private void Awake() {
        Instance = this;
    }

    #endregion






    public PlayerAnimationState currentAnimation = PlayerAnimationState.PLAYER_IDLE;

    public void ChangeAnimationState(PlayerAnimationState newAnimationState) {

        if (currentAnimation == newAnimationState) return;

        switch (newAnimationState) {
            case PlayerAnimationState.PLAYER_IDLE:
                animator.Play("Player_Idle");
                break;
            case PlayerAnimationState.PLAYER_MINING:
                animator.Play("Player_Mining");
                break;
            default:
                animator.Play("Player_Idle");
                break;

        }



        currentAnimation = newAnimationState;
    }
}

public enum PlayerAnimationState {
    PLAYER_MINING,
    PLAYER_IDLE
}
