using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AttackType
{
    Far,
    Hit,
}

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public NavMeshAgent navMeshAgent;
    private List<CharacterController> targets = new List<CharacterController>();
    public WeaponData weaponData;
    public WeaponHitData weaponHitData;
    public HatData hatData;
    public PantData pantData;
    public Weapon currentWeapon;
    public WeaponHit currentHitWeapon;
    public Hat currentHat;
    public Renderer currentPantRenderer;
    public Transform hand;
    public Transform head;
    public GameObject mask;
    public CharacterController target;
    public bool isDead;
    public bool isAttackNext = true;
    public float timerAttack;
    private string animName;
    public bool isCanThrow = true;
    public AttackType attackType;
    public int heath;
    protected virtual void Update()
    {
        timerAttack += Time.deltaTime;
        if (isAttackNext)
        {
            timerAttack = 0f;
        }

        if (timerAttack >= Constant.TIME_DELAY_ATTACK)
        {
            isAttackNext = true;
            if (attackType == AttackType.Far)
            {
                currentWeapon.gameObject.SetActive(true);
            }
            else
            {
                isCanThrow = true;
            }
        }
    }

    protected void ChangeWeapon(WeaponType weaponType)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        else
        {
            currentWeapon = Instantiate(weaponData.GetWaponeType(weaponType), hand);
        }
    }
    protected void ChangeWeaponHit(WeaponHitType weaponHitType)
    {
        if (currentHitWeapon != null)
        {
            Destroy(currentHitWeapon.gameObject);
        }
        else
        {
            currentHitWeapon = Instantiate(weaponHitData.GetWeaponHitType(weaponHitType), hand);
        }
    }
    protected void ChangeHat(HatType hatType)
    {
        if (currentHat != null)
        {
            Destroy(currentHat.gameObject);
        }
        else
        {
            currentHat = Instantiate(hatData.GetHatType(hatType), head);
        }
    }

    protected void ChangePant(PantType pantType)
    {
        currentPantRenderer.material = pantData.GetPantType(pantType);
    }

    public virtual void AddTarget(CharacterController target)
    {
        targets.Add(target);
    }

    public virtual void RemoveTarget(CharacterController target)
    {
        targets.Remove(target);
        this.target = null;
    }

    public CharacterController GetTargetInRange()
    {
        CharacterController target = null;
        if (targets != null)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (!targets[i].isDead)
                {
                    target = targets[i];
                    break;
                }
            }
        }

        return target;
    }

    public void OnAttack()
    {
        isCanThrow = false;
        target = GetTargetInRange();
        if (target != null)
        {
            transform.LookAt(target.transform.position + Vector3.up * (transform.position.y - target.transform.position.y));
            ChangeAnim(Constant.ANIM_ATTACK);
            if (attackType == AttackType.Hit)
            {
                currentHitWeapon.SetActiveCollider(true);
            }
            Invoke(nameof(Attack), Constant.TIME_DELAY_THROW);
        }
    }
    public void ChangeAnim(string animNameType)
    {
        if (animName != animNameType)
        {
            animator.ResetTrigger(animName);
            animName = animNameType;
            animator.SetTrigger(animName);
        }
    }

    public void SetMask(bool active)
    {
        mask.SetActive(active);
    }

    protected void Attack()
    {
        if (attackType == AttackType.Far)
        {
            isAttackNext = false;
            isCanThrow = true;
            currentWeapon.gameObject.SetActive(false);
            currentWeapon.Throw(hand.transform.position, transform.forward);
        }
        else
        {
            currentHitWeapon.SetActiveCollider(false);
            isAttackNext = false;
        }
    }

    public void OnDeath()
    {
        ChangeAnim(Constant.ANIM_DIE);
        StartCoroutine(DelayDie());
    }

    protected virtual IEnumerator DelayDie()
    {
        yield return new WaitForSeconds(3f);
    }
}