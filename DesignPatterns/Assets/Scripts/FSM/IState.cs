using System;

namespace DesignPatterns
{
    public interface IState
    {
        event Action<string> OnTransitionRequest;
        void EnterState();
        void Update();
        void ExitState();
    }
}