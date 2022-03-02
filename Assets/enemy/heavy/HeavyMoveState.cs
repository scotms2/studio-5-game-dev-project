using UnityEngine;

public class HeavyMoveState : HeavyBaseState
{
    public override void EnterState(HeavyStateManager heavy)
    {

    }

    public override void UpdateState(HeavyStateManager heavy)
    {
        Debug.Log("Heavy Move State");
    }

    public override void OnCollisionEnter(HeavyStateManager heavy, Collision collision)
    {

    }
}
