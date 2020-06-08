using System.Collections.Generic;

[System.Serializable]
public class State
{
    public StateMachine stateMachine;
    public List<Transition> transitions;


    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Run(float deltaTime) { }

    public void CheckTransitions()
    {
        Transition selectedTransition = null;

        foreach(Transition transition in transitions)
        {
            if(transition.CheckConditions())
            {
                if(transition == null)
                {
                    selectedTransition = transition;
                }
                else if(transition.priority > selectedTransition.priority)
                {
                    selectedTransition = transition;
                }
            }
        }

        if(selectedTransition != null && stateMachine != null)
        {
            stateMachine.SetState(selectedTransition.destination);
        }
    }
}