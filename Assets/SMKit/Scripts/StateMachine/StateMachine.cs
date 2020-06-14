using UnityEngine;

namespace SMKit.StateMachine
{
    [System.Serializable]
    public class StateMachine
    {
        [SerializeField] State currentState;

        public State CurrentState
        {
            get { return currentState; }
            set
            {
                if (currentState != null)
                {
                    currentState.Exit();
                    currentState = null;
                }

                if (value != null)
                {
                    currentState = value;
                    currentState.StateMachine = this;
                    currentState.Enter();
                }
            }
        }

        public void Run(float deltaTime)
        {
            if (currentState != null)
            {
                currentState.Run(deltaTime);

                Transition selectedTransition = StateMachineUtility.SelectTransition(currentState.Transitions);

                if (selectedTransition != null)
                {
                    if (selectedTransition.destination == null)
                        Debug.LogError("selectedTransition has null destination");

                    if (selectedTransition.destination is State destination)
                        CurrentState = destination;
                    else
                        Debug.LogError("selectedTransition destination is not a State");
                }
            }
        }
    }
}