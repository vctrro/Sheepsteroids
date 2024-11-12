using System;
using UnityEngine.Pool;

namespace Model
{
    public interface IPlayer : IObject2D, IMovable, ICollidable
    {
        public IGun Gun { get; set; }
    }
}
