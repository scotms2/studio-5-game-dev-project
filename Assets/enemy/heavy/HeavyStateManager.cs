using UnityEngine;

public class HeavyStateManager : MonoBehaviour
{

    HeavyBaseState currentState;
    public HeavyIdleState IdleState = new HeavyIdleState();
    public HeavyMoveState MoveState = new HeavyMoveState();
    public HeavyAttackState AttackState = new HeavyAttackState();
    public HeavyDieState DieState = new HeavyDieState();


    void Start()
    {
        currentState = IdleState;

        currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(HeavyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
