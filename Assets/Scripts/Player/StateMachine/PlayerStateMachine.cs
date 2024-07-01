using System.Collections.Generic;
using System.Linq;

public class PlayerStateMachine : IStateSwitcher
{
    private IState _currentState;
    private List<IState> _states;

    public PlayerStateMachine(PlayerController controller)
    {
        _states = new List<IState>()
        {
            new IdleState(this, controller),
            new WalkState(this, controller),
            new JumpState(this, controller),
            new FallState(this, controller)
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void TrySwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(s => s.GetType() == typeof(T));

        if (_currentState == state)
            return;

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }
}
