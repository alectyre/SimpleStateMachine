using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [System.Serializable]
    public abstract class State : IState
    {
        [SerializeField] IStateMachine stateMachine;
        [SerializeField] List<Transition> transitions;


        public IStateMachine StateMachine { get { return stateMachine; } set { stateMachine = value; } }
        public List<Transition> Transitions { get { return transitions; } }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Run(float deltaTime) { }
    }
}