using System.Collections;
using UnityEngine;

public class Bot : CharacterController
{
    private IState<Bot> currentState;
    private Vector3 destination;
    protected override void Update()
    {
        base.Update();
        if (!isDead)
        {
            if (currentState != null)
            {
                currentState.OnExecute(this);
            }
        }
        else
        {
            SetDestination(transform.position);
        }
    }
    public void OnInit()
    {
        if (attackType == AttackType.Far)
        {
            ChangeWeapon((weaponData.GetRandomItem()));
        }
        else
        {
            ChangeWeaponHit(weaponHitData.GetRandomItem());
        }
        ChangeHat(hatData.GetRandomItem());
        ChangePant(pantData.GetRandomItem());
    }
    public void SetDestination(Vector3 position)  
    {
        destination = position;
        destination.y= 0;
        navMeshAgent.SetDestination(position);
    }
    public void ChangeState(IState<Bot> state)
    {
        if (!isDead)
        {
            if (currentState != null)
            {
                currentState.OnExit(this);
            }
            currentState = state;
            if (currentState != null)
            {
                currentState.OnEnter(this);
            }
        }
    }
    public bool isDestination => Vector3.Distance(destination,Vector3.right * transform.position.x + Vector3.forward * transform.position.z) < 0.1f;
    protected override IEnumerator DelayDie()
    {
        yield return base.DelayDie();
        gameObject.SetActive(false);
    }

    public Vector3 GetRandomPosition()
    {
       return LevelManager.Ins.currentLevel.GetRandomPosition();
    }
}
