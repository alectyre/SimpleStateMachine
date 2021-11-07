using System;

namespace SimpleStateMachine
{
    public class SimpleState : State
    {
        public Action onEnter;

        public Action onRun;

        public Action onExit;



        public SimpleState(Action onEnter, Action onRun, Action onExit)
        {
            this.onEnter = onEnter;
            this.onRun = onRun;
            this.onExit = onExit;
        }

        public override void Enter()
        {
            onEnter?.Invoke();
        }

        public override void Run()
        {
            onRun?.Invoke();
        }

        public override void Exit()
        {
            onExit?.Invoke();
        }
    }
}