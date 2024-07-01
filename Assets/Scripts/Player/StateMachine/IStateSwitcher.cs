public interface IStateSwitcher
{
    public void TrySwitchState<T>() where T : IState;
}
