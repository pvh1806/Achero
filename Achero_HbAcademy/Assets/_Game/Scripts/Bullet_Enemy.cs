using System.ComponentModel.Design;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    private Vector3 direction;
    private float timer;

    public void OnInit(Vector3 driect)
    {
        direction = driect;
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(direction * 3f * Time.deltaTime);
        if (timer >= 2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            if (!characterController.isDead)
            {
                Destroy(gameObject);
                characterController.heath--;
                if( characterController.heath <= 0)
                {
                    characterController.isDead = true;
                    characterController.OnDeath();
                    LevelManager.Ins.currentLevel.amountTotal--;
                    CanvasManager.Ins.textAlive.SetText(LevelManager.Ins.currentLevel.amountTotal);
                }
               
            }
        }

        if (other.CompareTag(Constant.TAG_BLOCK))
        {
            Destroy(gameObject);
        }
    }
}