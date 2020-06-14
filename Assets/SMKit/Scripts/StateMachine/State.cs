using System.Collections.Generic;

namespace SMKit.StateMachine
{
    public abstract class State
    {
        StateMachine stateMachine;

        List<Transition> transitions = new List<Transition>();


        public StateMachine StateMachine { get { return stateMachine; } set { stateMachine = value; } }

        public List<Transition> Transitions { get { return transitions; } }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Run(float deltaTime) { }
    }
}