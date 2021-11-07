using UnityEngine;
using UnityEngine.UI;
using SimpleStateMachine;

public class StateMachineDemo : MonoBehaviour
{
    [SerializeField] private Image stateImage = null;
    [SerializeField] private Toggle greenToggle = null;
    [SerializeField] private Toggle redToggle = null;
    [SerializeField] private Toggle blueToggle = null;

    StateMachine stateMachine;



    private void Awake()
    {
        stateMachine = new StateMachine();
        
        State greenState = new SimpleState(() =>
        {
            Debug.Log("Entered GreenState");
            stateImage.color = Color.green;
        },
        null,
        () =>
        {
            Debug.Log("Exit GreenState");
        });

        State redState = new SimpleState(() =>
        {
            Debug.Log("Exited GreenState");
            stateImage.color = Color.red;
        },
        null,
        () =>
        {
            Debug.Log("Entered RedState");
        });

        State blueState = new SimpleState(() =>
        {
            Debug.Log("Entered BlueState");
            stateImage.color = Color.blue;
        },
        null,
        () =>
        {
            Debug.Log("Exited BlueState");
        });

        greenState.Transitions.Add(new Transition(redState, () => !greenToggle.isOn && redToggle.isOn));
        greenState.Transitions.Add(new Transition(blueState, 1, () => !greenToggle.isOn && blueToggle.isOn));

        redState.Transitions.Add(new Transition(greenState, () => greenToggle.isOn));
        redState.Transitions.Add(new Transition(blueState, () => !redToggle.isOn && blueToggle.isOn));

        blueState.Transitions.Add(new Transition(greenState, () => greenToggle.isOn));
        blueState.Transitions.Add(new Transition(redState, () => !blueToggle.isOn && redToggle.isOn));

        stateMachine.CurrentState = greenState;
    }

    private void Update()
    {
        stateMachine.CheckForTransition();
        stateMachine.RunState();
    }
}
