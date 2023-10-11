using System.Collections;
using UnityEngine;

public class BotEnemy : MonoBehaviour
{
    [SerializeField] private Bullet_Enemy bulletPrefab;
    [SerializeField] private GameObject posHand;
    [SerializeField] private Animator animator;
    private string animName;
    private float timerAttackNext = 0f;
    private bool isAttackNext = true;

    void Update()
    {
        timerAttackNext += Time.deltaTime;

        if (isAttackNext && timerAttackNext >= 1f)
        {
            isAttackNext = false;
            timerAttackNext = 0f;
            ChangeAnim(Constant.ANIM_ATTACK);
            transform.LookAt(LevelManager.Ins.playerController.transform.position + Vector3.up * (transform.position.y - LevelManager.Ins.playerController.transform.position.y));
            StartCoroutine(ThrowAfterDelay(0.2f));
        }
        else if (!isAttackNext && timerAttackNext >= 1f)
        {
            isAttackNext = true;
        }
    }

    private IEnumerator ThrowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Throw(posHand.transform.position, LevelManager.Ins.playerController.transform.position);
        ChangeAnim(Constant.ANIM_IDLE);
    }

    private void Throw(Vector3 positionHand, Vector3 direction)
    {
        Bullet_Enemy bullet = Instantiate(bulletPrefab, positionHand, Quaternion.identity);
        bullet.OnInit(direction);
    }

    private void ChangeAnim(string animNameType)
    {
        if (animName != animNameType)
        {
            animator.ResetTrigger(animName);
            animName = animNameType;
            animator.SetTrigger(animName);
        }
    }
}