public class IdleState : BaseState
{
    public IdleState(IStateSwitcher stateSwitcher, PlayerController playerController) : base(stateSwitcher, playerController)
    {
    }

    public override void Enter()
    {
        base.Enter();

        PlayerController.Animator.StartIdle();
        PlayerController.Input.Movement.Jump.started += OnJumpKeyPressed;
    }

    public override void Update()
    {
        base.Update();

        if (HorizontalInput != 0)
            StateSwitcher.TrySwitchState<WalkState>();
    }

    public override void Exit() 
    {
        base.Exit();

        PlayerController.Animator.StopIdle();
        PlayerController.Input.Movement.Jump.started -= OnJumpKeyPressed;
    }

    private void OnJumpKeyPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (PlayerController.OnGround)
            StateSwitcher.TrySwitchState<JumpState>();
    }
}
