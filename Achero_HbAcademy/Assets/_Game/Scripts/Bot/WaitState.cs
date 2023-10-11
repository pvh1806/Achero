using System.Collections;
using UnityEngine;

public class WaitState : IState<Bot>
{
    public void OnEnter(Bot t)
    {  
        t.ChangeAnim(Constant.ANIM_IDLE);
        t.StartCoroutine(ChangeStateIdleAfterDelay(t, 2f));
    }

    public void OnExecute(Bot t)
    {
        if (t.isAttackNext && t.isCanThrow && t.GetTargetInRange() != null)
        {
            t.ChangeState(new PatrolState());
            t.CancelInvoke(nameof(ChangeStateIdleAfterDelay));
        }
    }

    public void OnExit(Bot t)
    {
       
    }
    private IEnumerator ChangeStateIdleAfterDelay(Bot t, float delay)
    {
        yield return new WaitForSeconds(delay);
        t.ChangeState(new IdleState());
    }
}
