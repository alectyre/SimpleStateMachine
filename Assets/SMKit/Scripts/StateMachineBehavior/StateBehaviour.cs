using System.Collections.Generic;
using UnityEngine;

namespace SMKit.Unity
{
    public abstract class StateBehaviour : MonoBehaviour
    {
        [SerializeField] string stateName;

        [SerializeField] List<Transition> transitions;

        StateMachineBehaviour stateMachine;


        public string StateName { get { return StateName; } }

        public StateMachineBehaviour StateMachine { get { return stateMachine; } set { stateMachine = value; } }

        public List<Transition> Transitions { get { return transitions; } }

        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}