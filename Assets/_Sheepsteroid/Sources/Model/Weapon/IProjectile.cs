using System;
using UnityEngine;

namespace Model
{
    public interface IProjectile : IObject2D, ICollidable
    {
        public Action OnShoot { get; set; }
        public float LifeTime { get; set; }

        public void Fire();
    }  
}

