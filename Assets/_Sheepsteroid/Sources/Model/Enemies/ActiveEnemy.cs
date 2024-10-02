using System;
using UnityEngine;

namespace Model
{
    public class ActiveEnemy : Enemy
    {
        private readonly Player _target;

        public ActiveEnemy(Player player)
        {
            _target = player;
        }

        public override void Update(Vector2 position)
        {
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector2.up, (_target.Position - position)));
            base.Update(position);
            Move();
        }
    }
}

