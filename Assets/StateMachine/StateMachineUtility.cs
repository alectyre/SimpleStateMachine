using System.Collections.Generic;

namespace StateMachine
{
    public class StateMachineUtility
    {
        public static void CheckTransitions(IStateMachine stateMachine, List<Transition> transitions)
        {
            Transition selectedTransition = null;

            foreach (Transition transition in transitions)
            {
                if (transition.CheckConditions())
                {
                    if (transition == null)
                    {
                        selectedTransition = transition;
                    }
                    else if (transition.priority > selectedTransition.priority)
                    {
                        selectedTransition = transition;
                    }
                }
            }

            if (selectedTransition != null)
            {
                stateMachine.CurrentState = selectedTransition.destination;
            }
        }
    }
}