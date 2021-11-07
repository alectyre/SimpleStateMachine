using System.Collections.Generic;

namespace SimpleStateMachine
{
    public abstract class State
    {
        private readonly List<Transition> transitions = new List<Transition>();



        public List<Transition> Transitions { get { return transitions; } }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Run() { }
    }
}