using System.Collections.Generic;

namespace SMKit
{
    public class StateMachineUtility
    {
        public static Transition SelectTransition(List<Transition> transitions)
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