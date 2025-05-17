using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;

    public void SwitchState(State state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    private void Update()
    {
        currentState?.Tick();
    }
}

public abstract class State
{
    public abstract void Enter();
    public abstract void Tick();
    public abstract void Exit();
}
