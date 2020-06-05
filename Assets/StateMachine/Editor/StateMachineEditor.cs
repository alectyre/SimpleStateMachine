using UnityEditor;

[CustomEditor(typeof(StateMachine))]
public class StateMachineEditor : Editor
{

    public override void OnInspectorGUI()
    {
        StateMachine stateMachine = (StateMachine)target;

        if (stateMachine.CurrentState != null)
            EditorGUILayout.LabelField("Current State:", stateMachine.CurrentState.GetType().Name);
        else
            EditorGUILayout.LabelField("Current State:", "None");
    }
}
