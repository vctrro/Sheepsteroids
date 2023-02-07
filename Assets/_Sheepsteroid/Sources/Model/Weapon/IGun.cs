using System;
using UnityEngine;

namespace Model
{
    public interface IGun
    {
        public IProjectile Projectile { get; set; }

        public void Shoot();
    }  
}

