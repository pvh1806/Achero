using System;
using System.Collections;
using UnityEngine;

public class PlayerController : CharacterController
{
    private float moveSpeed = 6f;
    [SerializeField] FloatingJoystick floatingJoystick;
    private void Start()
    {
        OnInit();
        transform.position = new Vector3(-5.36f, transform.position.y,-0.5f);
    }

    protected override void Update()
    {
        base.Update();
        Vector3 joystickInput = new Vector3(floatingJoystick.Horizontal, 0f, floatingJoystick.Vertical).normalized;
        if (!isDead)
        {
            if (joystickInput.magnitude >= 0.1f)
            {
                MovePlayer(joystickInput);
                ChangeAnim(Constant.ANIM_RUN);
                if (!isCanThrow)
                {
                    CancelInvoke(nameof(Attack));
                    isCanThrow= true;
                }
            }
            else
            {
                if(isAttackNext && isCanThrow && GetTargetInRange() != null)
                {
                    OnAttack();
                }
                if(isCanThrow && GetTargetInRange() == null && isAttackNext)
                {
                    ChangeAnim(Constant.ANIM_IDLE);
                }
                
            }
        }
        if (LevelManager.Ins.currentLevel.amountTotal <= 1)
        {
            CanvasManager.Ins.uiMainMenu.gameObject.SetActive(true);
            floatingJoystick.Horizontal = 0f;
            floatingJoystick.Vertical = 0f;
            CanvasManager.Ins.floatingJoystick.gameObject.SetActive(false);
            CanvasManager.Ins.textAlive.gameObject.SetActive(true);
            LevelManager.Ins.OnLoadLevel(LevelManager.Ins.NextLevel());
        }
    }
    private void MovePlayer(Vector3 direction)
    {
        Vector3 movement = Camera.main.transform.TransformDirection(direction);
        movement.y = 0f;
        navMeshAgent.Move(movement * moveSpeed * Time.deltaTime);
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    public void OnInit()
    {
        if (attackType == AttackType.Far)
        {
            ChangeWeapon(WeaponType.candy_2);
        }
        else
        {
            ChangeWeaponHit(WeaponHitType.uzi);
        }
        ChangeHat(HatType.arow);
        ChangePant(PantType.pant);
    }

    public override void AddTarget(CharacterController target)
    {
        base.AddTarget(target);
        target.SetMask(true);
    }

    public override void RemoveTarget(CharacterController target)
    {
        base.RemoveTarget(target);
        target.SetMask(false);
    }

    protected override IEnumerator DelayDie()
    {
        yield return StartCoroutine(base.DelayDie());
        
    }
    
}