using System;
using UnityEngine.Pool;

namespace Model
{
    public interface IEnemy : IObject2D, IMovable 
    {
        public Action<Enemy> OnCollisionWithProjectile { get; set; }

        public void Collision(ICollidable collider);
    }
}
