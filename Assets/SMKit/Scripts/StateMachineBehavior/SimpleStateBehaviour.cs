using UnityEngine.Events;

namespace SMKit.Unity
{
    public class SimpleStateBehaviour : StateBehaviour
    {
        public UnityEvent onEnter;
        public UnityEvent onExit;

        public override void Enter()
        {
            onEnter?.Invoke();
        }

        public override void Exit()
        {
            onExit?.Invoke();
        }
    }
}