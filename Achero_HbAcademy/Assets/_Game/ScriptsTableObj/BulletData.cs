using UnityEngine;
public enum BulletType
{   
    uzi  = 0,
    z = 1,
    candy_2 = 2,
    candy_3 = 3,
}
[CreateAssetMenu(fileName = "ColorBullet", menuName = "ScriptableObjects/ColorBullet")]
public class BulletData : ScriptableObject
{

    [SerializeField] private Bullet[] bulletObj;
    public BulletType bulletType;
    public Bullet GetBulletType(BulletType bulletType)
    {
        return bulletObj[(int)bulletType];
    }
}