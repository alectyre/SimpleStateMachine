using System.Collections.Generic;

namespace SimpleStateMachine
{
    public class StateMachine
    {
        private State currentState;



        public State CurrentState
        {
            get { return currentState; }
            set
            {
                if (currentState != value && currentState != null)
                {
                    currentState.Exit();
                    currentState = null;
                }

                if (value != null)
                {
                    currentState = value;
                    currentState.Enter();
                }
            }
        }

        public void CheckForTransition()
        {
            if (currentState != null)
            {
                Transition selectedTransition = SelectTransition(currentState.Transitions);

                if (selectedTransition != null)
                {
                    if (selectedTransition.destination == null)
                        UnityEngine.Debug.LogError("Selected Transition has a null destination.");

                    CurrentState = selectedTransition.destination;
                }
            }
        }

        public void RunState()
        {
            if (currentState != null)
            {
                currentState.Run();
            }
        }

        private static Transition SelectTransition(List<Transition> transitions)
        {
            Transition selectedTransition = null;

            foreach (Transition transition in transitions)
            {
                if (transition.CheckConditions())
                {
                    if (selectedTransition == null)
                    {
                        selectedTransition = transition;
                    }
                    else if (transition.priority > selectedTransition.priority)
                    {
                        selectedTransition = transition;
                    }
                }
            }

            return selectedTransition;
        }
    }
}