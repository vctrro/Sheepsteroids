using System;
using UnityEngine;

namespace Model
{
	public class SplittableEnemy : Enemy, ISplittableEnemy
    {
        public Action<IEnemy> OnSplit { get; set; }

        protected override void CollisionWithProjectile(IProjectile projectile)
        {
            if (projectile is IBullet)
            {
                OnSplit?.Invoke(this);
            }

            base.CollisionWithProjectile(projectile);
        }
    }
}

