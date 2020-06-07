using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition
{
    public int priority;
    public State destination;

    delegate bool Condition();

    List<Condition> conditions;

    public bool CheckConditions()
    {
        for (int i = 0; i < conditions.Count; i++)
            if (conditions[i].Invoke())
                return true;

        return false;
    }
}
