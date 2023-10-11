using UnityEngine;

public class CharacterSight : MonoBehaviour
{
    [SerializeField] CharacterController character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            CharacterController target = other.GetComponent<CharacterController>();
            character.AddTarget(target);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            CharacterController target = other.GetComponent<CharacterController>();
            character.RemoveTarget(target);
        }
    }
}