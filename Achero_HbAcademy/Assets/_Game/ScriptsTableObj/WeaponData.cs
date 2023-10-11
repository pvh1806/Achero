using UnityEngine;
public enum WeaponType
{   
    uzi  = 0,
    z = 1,
    candy_2 = 2,
    candy_3 = 3,
}
[CreateAssetMenu(fileName = "ColorWeapon", menuName = "ScriptableObjects/ColorWeapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private Weapon[] weaponObj;
    public WeaponType weaponType;
    public Weapon GetWaponeType(WeaponType weaponType)
    {
        return weaponObj[(int)weaponType];
    }
    public WeaponType GetRandomItem()
    {
        int randomValue =  Random.Range(0,3);
        WeaponType randomItemType = (WeaponType)randomValue;
        return randomItemType;
    }
}
