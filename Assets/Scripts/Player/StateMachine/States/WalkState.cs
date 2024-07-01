using UnityEngine;

public class WalkState : BaseState
{
    private Vector3 _turnRight = Vector3.zero;
    private Vector3 _turnLeft = new Vector3(0, 180, 0);

    public WalkState(IStateSwitcher stateSwitcher, PlayerController playerController) : base(stateSwitcher, playerController)
    {
    }

    public override void Enter()
    {
        base.Enter();

        PlayerController.Animator.StartWalk();
        PlayerController.Input.Movement.Jump.started += OnJumpKeyPressed;
    }

    public override void Update()
    {
        base.Update();

        SetVelocity();
        SetRotation();

        if (HorizontalInput == 0)
            StateSwitcher.TrySwitchState<IdleState>();
    }

    private void SetVelocity()
    {
        PlayerController.Rigidbody.velocity = Vector2.right * HorizontalInput * PlayerController.StatsConfig.MovementConfig.Speed;
    }

    private void SetRotation()
    {
        if (HorizontalInput < 0)
            PlayerController.transform.eulerAngles = _turnLeft;
        else if (HorizontalInput > 0)
            PlayerController.transform.eulerAngles = _turnRight;
    }

    public override void Exit()
    {
        base.Exit();

        PlayerController.Animator.StopWalk();
        PlayerController.Input.Movement.Jump.started -= OnJumpKeyPressed;
    }

    private void OnJumpKeyPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (PlayerController.OnGround)
            StateSwitcher.TrySwitchState<JumpState>();
    }
}