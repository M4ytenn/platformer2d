using UnityEngine;

public class FallState : IState
{
    private IStateSwitcher _stateSwitcher;
    private PlayerController _controller;

    public FallState(IStateSwitcher stateSwitcher, PlayerController controller)
    {
        _stateSwitcher = stateSwitcher;
        _controller = controller;
    }

    public void Enter()
    {
        Debug.Log("Fall State Enter");
        _controller.Animator.StartFall();
    }

    public void Update()
    {
        Debug.Log("Fall State Update");

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

        if (Mathf.Abs(_controller.Rigidbody.velocity.y) < 0.1f)
        {
            _stateSwitcher.TrySwitchState<IdleState>();
        }
    }

    public void Exit()
    {
        Debug.Log("Fall State Exit");
        _controller.Animator.StopFall();
    }
}
