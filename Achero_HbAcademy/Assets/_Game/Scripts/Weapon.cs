using System;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    public BulletType bulletType;
    public BulletData bulletData;
    public void Throw( Vector3 positionHand , Vector3 direction )
    {
        Bullet bulletPrefab = bulletData.GetBulletType(bulletType);
        Bullet bullet = Instantiate(bulletPrefab, positionHand, bulletPrefab.transform.rotation);
        bullet.OnInit(direction);
    }
}
