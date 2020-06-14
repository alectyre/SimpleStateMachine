using System;

namespace SMKit.StateMachine
{
    public class SimpleState : State
    {
        public string name;
        public Action onEnter;
        public Action onExit;


        public SimpleState() : this(null, null) { }

        public SimpleState(Action onEnter, Action onExit) : this("", onEnter, onExit) { }
     
        public SimpleState(string name, Action onEnter, Action onExit)
        {
            this.name = name;
            this.onEnter = onEnter;
            this.onExit = onExit;
        }

        public override void Enter()
        {
            onEnter?.Invoke();
        }

        public override void Exit()
        {
            onExit?.Invoke();
        }
    }
}