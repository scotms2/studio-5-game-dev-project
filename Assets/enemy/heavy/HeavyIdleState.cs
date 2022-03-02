using UnityEngine;

public class HeavyIdleState : HeavyBaseState
{
    public override void EnterState(HeavyStateManager heavy)
    {
        Debug.Log("Heavy Idle State");
    }

    public override void UpdateState(HeavyStateManager heavy)
    {

    }

    public override void OnCollisionEnter(HeavyStateManager heavy, Collision collision)
    {

    }
}
