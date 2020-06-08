using System.Collections.Generic;

namespace StateMachine
{
    public interface IState
    {
        IStateMachine StateMachine { get; set; }
        List<Transition> Transitions  { get; }

        void Enter();

        void Exit();

        void Run(float deltaTime);       
    }
}