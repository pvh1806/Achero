using UnityEngine;

public class PatrolState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        t.isCanThrow = true;
    }
    public void OnExecute(Bot t)
    {
        if(t.isAttackNext && t.isCanThrow && t.GetTargetInRange() != null)
        {
            t.OnAttack();
        }
        if(t.isCanThrow && t.GetTargetInRange() == null && t.isAttackNext)
        {
            t.ChangeState(new WaitState());
        }
    }

    public void OnExit(Bot t)
    {
    }
}