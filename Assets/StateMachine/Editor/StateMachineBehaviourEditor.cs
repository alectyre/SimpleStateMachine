using UnityEditor;

namespace StateMachine
{
    [CustomEditor(typeof(StateMachineBehaviour))]
    public class StateMachineBehaviorEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            StateMachineBehaviour stateMachine = (StateMachineBehaviour)target;

            if (stateMachine.CurrentState != null)
                EditorGUILayout.LabelField("Current State:", stateMachine.CurrentState.GetType().Name);
            else
                EditorGUILayout.LabelField("Current State:", "None");
        }
    }
}