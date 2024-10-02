using System;
using UnityEngine;

namespace Model
{
    public abstract class MovableObject : Object2D, IMovable
    {
        public Action<float> OnMove { get; set; }
        public Action<Vector2> OnTeleport { get; set; }
        public CheckBorder OnCheckBorder { get; set; }
        public float Speed { get; set; }

        public virtual void Move()
        {
            OnMove?.Invoke(Speed);
        }

        public virtual void Update(Vector2 position)
        {
            OutOfScreen(position);
            Position = position;
        }

        public void Rotate(float angle)
        {
            Rotation = Mathf.Repeat(Rotation + angle, 360);
        }

        protected virtual void OutOfScreen(Vector2 position)
        {
            if (OnCheckBorder(ref position))
            {
                OnTeleport?.Invoke(position);
            }
        }
    }
}
