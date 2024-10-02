using System;
using UnityEngine;

namespace Model
{
    public class Bullet : MovableObject, IBullet
    {
        public Action OnShoot { get; set; }
        public float LifeTime { get; set; }
        private GameTimer _timer;

        public Bullet()
        {
            _timer = new GameTimer();
        }

        public void Fire()
        {
            OnShoot?.Invoke();
            _timer.Start(LifeTime);
            _timer.OnTimerFinish = Destroy;
            base.Move();
        }

        public ICollidable Collision()
        {
            Destroy();
            return this;
        }

        //teleport off
        protected override void OutOfScreen(Vector2 position)
        {
            if (OnCheckBorder(ref position))
            {
                Destroy();
            }
        }

        protected override void Destroy()
        {
            _timer.Stop();
            base.Destroy();
        }
    }
}

