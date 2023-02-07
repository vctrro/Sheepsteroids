using System;
using UnityEngine;

namespace Model
{
    public class Enemy : MovableObject, IEnemy
    {
        public Action<Enemy> OnCollisionWithProjectile { get; set; }

        public override void Update(Vector2 position)
        {
            base.Update(position);
            Move();
        }

        public void Collision(ICollidable collider)
        {
            if (collider is IProjectile)
            {
                CollisionWithProjectile((collider as IProjectile));
            }
        }

        protected virtual void CollisionWithProjectile(IProjectile projectile)
        {
            OnCollisionWithProjectile?.Invoke(this);
            Destroy();
        }
    }
}

