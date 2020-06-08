[System.Serializable]
public class StateMachine
{
    public State CurrentState { get { return currentState; } }

    State currentState;

    public void Run(float deltaTime)
    {
        if (currentState != null)
        {
            currentState.Run(deltaTime);
            currentState.CheckTransitions();
        }
    }

    public void SetState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
            currentState = null; //Any good reason to do this?
        }

        if (newState != null)
        {
            currentState = newState;
            currentState.stateMachine = this;
            currentState.Enter();
        }
    }
}