using UnityEngine;

public abstract class HeavyBaseState
{
    public abstract void EnterState(HeavyStateManager heavy);

    public abstract void UpdateState(HeavyStateManager heavy);

    public abstract void OnCollisionEnter(HeavyStateManager heavy, Collision collision);
}
