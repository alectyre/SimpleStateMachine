using UnityEngine;
using UnityEngine.UI;
using SMKit;
using SMKit.StateMachine;

public class StatemachineTest : MonoBehaviour
{
    [SerializeField] Image stateImage;
    [SerializeField] Toggle greenToggle;
    [SerializeField] Toggle redToggle;
    [SerializeField] Toggle blueToggle;

    StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new StateMachine();

        State greenState = new SimpleState("Green State", () => {
            Debug.Log("Entered GreenState");
            stateImage.color = Color.green;
        }, () => {
            Debug.Log("Exit GreenState");
        });
        State redState = new SimpleState("Red State", () => {
            Debug.Log("Exited GreenState");
            stateImage.color = Color.red;
        }, () => {
            Debug.Log("Entered RedState");
        });
        State blueState = new SimpleState("Blue State", () => {
            Debug.Log("Entered BlueState");
            stateImage.color = Color.blue;
        }, () => {
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
        stateMachine.Run(Time.deltaTime);
    }
}
