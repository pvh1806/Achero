using System.ComponentModel.Design;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        transform.Translate(direction * 5f * Time.deltaTime);
        if (timer >= 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
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