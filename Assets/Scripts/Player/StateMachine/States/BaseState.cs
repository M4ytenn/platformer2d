using UnityEngine;

public class BaseState : IState
{
    protected IStateSwitcher StateSwitcher;
    protected PlayerController PlayerController;
    
    protected float HorizontalInput => PlayerController.Input.Movement.Move.ReadValue<float>();

    public BaseState(IStateSwitcher stateSwitcher, PlayerController playerController)
    {
        StateSwitcher = stateSwitcher;
        PlayerController = playerController;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter state: " + GetType());
    }

    public virtual void Exit()
    {
        Debug.Log("Exit state: " + GetType());
    }

    public virtual void Update()
    {
        Debug.Log("Update state: " + GetType());

        if (PlayerController.Rigidbody.velocity.y < 0)
            StateSwitcher.TrySwitchState<FallState>();
    }
}