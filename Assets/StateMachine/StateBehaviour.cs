using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateBehaviour : MonoBehaviour, IState
    {
        [SerializeField] IStateMachine stateMachine;
        [SerializeField] List<Transition> transitions;


        public IStateMachine StateMachine { get { return stateMachine; } set { stateMachine = value; } }
        public List<Transition> Transitions { get { return transitions; } }

        public void Enter() { }

        public void Exit() { }

        public void Run(float deltaTime) { }
    }
}