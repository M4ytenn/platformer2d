using UnityEngine;

public class JumpState : IState
{
    private IStateSwitcher _stateSwitcher;
    private PlayerController _controller;

    public JumpState(IStateSwitcher stateSwitcher, PlayerController controller)
    {
        _stateSwitcher = stateSwitcher;
        _controller = controller;
    }

    public void Enter()
    {
        Debug.Log("Jump State Enter");
        _controller.Rigidbody.AddForce(Vector2.up * _controller.StatsConfig.MovementConfig.JumpPower, ForceMode2D.Impulse);
        _controller.Animator.StartJump();
    }

    public void Update()
    {
        Debug.Log("Jump State Update");

        float horizontalInput = _controller.Input.Movement.Move.ReadValue<float>();
        _controller.Rigidbody.velocity = new Vector2(horizontalInput * _controller.StatsConfig.MovementConfig.Speed, _controller.Rigidbody.velocity.y);

        if (horizontalInput < 0)
        {
            _controller.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (horizontalInput > 0)
        {
            _controller.transform.eulerAngles = Vector3.zero;
        }

        if (_controller.Rigidbody.velocity.y < 0)
        {
            _stateSwitcher.TrySwitchState<FallState>();
        }
    }

    public void Exit()
    {
        Debug.Log("Jump State Exit");
        _controller.Animator.StopJump();
    }
}
