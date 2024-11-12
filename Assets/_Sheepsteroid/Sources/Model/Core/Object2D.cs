using System;
using UnityEngine;

namespace Model
{
    public abstract class Object2D : IObject2D
    {
        public Action OnDestroy { get; set; }
        public Action<float> OnRotate { get; set; }
        public Action<Vector2, float> OnInit { get; set; }

        private float _rotation;

        public Vector2 Position { get; protected set; }
        public float Rotation
        {
            get => _rotation;
            protected set
            {
                _rotation = value;
                OnRotate?.Invoke(_rotation);
            }
        }

        public virtual void Init(Vector2 position, float rotation = 0.0f)
        {
            Position = position;
            Rotation = rotation;
            OnInit?.Invoke(position, rotation);
        }

        protected virtual void Destroy()
        {
            OnDestroy?.Invoke();
        }
    }
}
