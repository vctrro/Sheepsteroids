using System;
using UnityEngine;

namespace Model
{
    public class Player : MovableObject, IPlayer
    {
        public IGun Gun { get; set; }

        public ICollidable Collision()
        {
            Destroy();
            return this;
        }
    }
}
