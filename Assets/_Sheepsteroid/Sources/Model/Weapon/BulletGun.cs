using System;
using UnityEngine;

namespace Model
{
    public class BulletGun : IGun
    {
        public IProjectile Projectile { get; set; }

        public void Shoot()
        {
            Projectile.Fire();
        }
    }  
}

