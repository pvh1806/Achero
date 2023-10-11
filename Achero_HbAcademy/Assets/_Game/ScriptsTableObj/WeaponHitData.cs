using UnityEngine;
public enum WeaponHitType
{   
    uzi  = 0,
    z = 1,
    candy_2 = 2,
    candy_3 = 3,
}
[CreateAssetMenu(fileName = "ColorWeaponHit", menuName = "ScriptableObjects/ColorWeaponHit")]
public class WeaponHitData : ScriptableObject
{

    [SerializeField] private WeaponHit[] weaponObj;
    public WeaponType weaponType;
    public WeaponHit GetWeaponHitType(WeaponHitType weaponHitType)
    {
        return weaponObj[(int) weaponHitType];
    }
    public WeaponHitType GetRandomItem()
    {
        int randomValue =  Random.Range(0,3);
        WeaponHitType randomItemType = (WeaponHitType)randomValue;
        return randomItemType;
    }
}