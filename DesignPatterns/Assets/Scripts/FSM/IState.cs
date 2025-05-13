namespace DesignPatterns
{
    public interface IState
    {
        void EnterState();
        void Update();
        void ExitState();
    }
}