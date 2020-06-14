using System.Collections.Generic;
using System;

namespace SMKit
{
    [Serializable]
    public class Transition
    {
        public int priority;

        public object destination;

        List<Func<bool>> conditions;


        public Transition() : this(null, 0, null) { }

        public Transition(object destination) : this(destination, 0, null) { }

        public Transition(object destination, params Func<bool>[] conditions) : this(destination, 0, conditions) { }

        public Transition(object destination, int priority, params Func<bool>[] conditions)
        {
            this.destination = destination;
            this.priority = priority;
            this.conditions = new List<Func<bool>>(conditions);
        }

        public void AddCondition(Func<bool> condition)
        {
            conditions.Add(condition);
        }

        public void RemoveCondition(Func<bool> condition)
        {
            conditions.Remove(condition);
        }

        public bool CheckConditions()
        {
            for (int i = 0; i < conditions.Count; i++)
                if (conditions[i].Invoke())
                    return true;

            return false;
        }
    }
}