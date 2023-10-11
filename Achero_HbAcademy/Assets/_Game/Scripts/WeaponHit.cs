using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    [SerializeField] private SphereCollider sphereCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            if (!characterController.isDead)
            {
                characterController.heath--;
                if ( characterController.heath == 0)
                {
                    characterController.isDead = true;
                    characterController.OnDeath();
                    LevelManager.Ins.currentLevel.amountTotal--;
                    CanvasManager.Ins.textAlive.SetText(LevelManager.Ins.currentLevel.amountTotal);
                }
            }
        }

    }

    public void SetActiveCollider(bool isStatus)
    {
        if (isStatus)
        {
            sphereCollider.enabled = true;
        }
        else
        {
            sphereCollider.enabled = false;
        }
    }
}
