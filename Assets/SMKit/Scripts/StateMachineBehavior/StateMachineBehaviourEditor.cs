using UnityEditor;

namespace SMKit.Unity
{
    [CustomEditor(typeof(StateMachineBehaviour))]
    public class StateMachineBehaviorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            StateMachineBehaviour stateMachine = (StateMachineBehaviour)target;

            StateBehaviour stateBehaviour = stateMachine.CurrentState as StateBehaviour;

            if (stateBehaviour != null)
                EditorGUILayout.LabelField("Current State:", stateBehaviour.StateName);
            else
                EditorGUILayout.LabelField("Current State:", "None");
        }
    }
}