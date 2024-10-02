using System;
using UnityEngine;

namespace Model
{
    public interface IObject2D
    {
        public Action OnDestroy { get; set; }
        public Action<float> OnRotate { get; set; }
        public Action<Vector2, float> OnInit { get; set; }

        public Vector2 Position { get; }
        public float Rotation { get; }

        public void Init(Vector2 position, float rotation = 0.0f);
    }
}
