using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Model
{
    public delegate bool CheckBorder(ref Vector2 position);
    public interface IMovable
    {
        public Action<float> OnMove { get; set; }
        public Action<Vector2> OnTeleport { get; set; }
        public CheckBorder OnCheckBorder { get; set; }
        public float Speed { get; set; }

        public void Move();
        public void Rotate(float angle);
        public void Update(Vector2 position);
    }
}

