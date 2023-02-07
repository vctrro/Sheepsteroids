using System;
using UnityEngine;

namespace Model
{
    public class Laser : Object2D, ILaser
    {
        public Action OnShoot { get; set; }
        public float LifeTime { get; set; }
        internal bool IsShoot { get; private set; }
        private IPlayer _player;
        private Timer _timer;

        public Laser(IPlayer player)
        {
            _player = player;
            _timer = new Timer();
        }

        public void Fire()
        {
            OnShoot?.Invoke();
            _timer.Start(LifeTime);
            IsShoot = true;
            _timer.OnTimerFinish = () =>
            {
                IsShoot = false;
                Destroy();
            };
        }

        protected override void Destroy()
        {
            _timer.Stop();
            base.Destroy();
        }

        public ICollidable Collision()
        {
            return this;
        }
    }
}

