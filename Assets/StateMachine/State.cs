using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State
{
    public List<Transition> transitions;

    bool isRunning;
    bool isTransitioning;

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Run(float deltaTime) { }

    void CheckTransitions()
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

        if(selectedTransition != null)
        {
            //Start transition
        }
    }
}