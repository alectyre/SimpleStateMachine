using UnityEngine;

namespace SMKit.Unity
{
    public class StateMachineBehaviour : MonoBehaviour
    {
        [SerializeField] StateBehaviour currentState;

        public StateBehaviour CurrentState
        {
            get { return currentState; }
            set
            {
                if (currentState != null)
                {
                    currentState.Exit();
                    currentState = null; //Any good reason to do this?
                }

                if (value != null)
                {
                    currentState = value;
                    currentState.StateMachine = this;
                    currentState.Enter();
                }
            }
        }

        private void LateUpdate()
        {
            if (currentState != null)
            {
                Transition selectedTransition = StateMachineUtility.SelectTransition(currentState.Transitions);

                if (selectedTransition != null)
                {
                    if (selectedTransition.destination == null)
                        Debug.LogError("Selected Transition has null destination.");

                    if (selectedTransition.destination is StateBehaviour destination)
                        CurrentState = destination;
                    else
                        Debug.LogError("Selected Transition's destination is not a StateBehaviour.");
                }
            }
        }
    }
}