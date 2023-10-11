using UnityEngine;

public enum BotType
{
    SetDes = 0,
    Attack = 1,
}

public class IdleState : IState<Bot>
{
    private bool hasRandom;

    public void OnEnter(Bot t)
    {
        Vector3 target;
        target = t.GetRandomPosition();
        hasRandom = true;
        if (t.attackType == AttackType.Hit)
        {
            t.currentHitWeapon.SetActiveCollider(false);
        }
        t.ChangeAnim(Constant.ANIM_RUN);
        t.SetDestination(target);
    }
    
    public void OnExecute(Bot t)
    {
        if (hasRandom && t.attackType == AttackType.Far)
        {
            if (t.isCanThrow && t.isAttackNext && t.GetTargetInRange()!=null)
            {
                BotType botType = GetRandomType();
                if (botType == BotType.Attack)
                {
                    t.SetDestination(t.transform.position);
                }
                else
                {
                    t.isCanThrow = false;
                }
                hasRandom = false;
            }
        }
        if (t.isDestination)
        {
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Bot t)
    {
    }

    private BotType GetRandomType()
    {
        int randomValue = Random.Range(0, 1);
        BotType randomType = (BotType)randomValue;
        return randomType;
    }
}