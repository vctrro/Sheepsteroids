using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Model
{
    public class LaserGun : IGun
    {
        public Action<int> OnCapacityChanged { get; set; }
        public IProjectile Projectile { get; set; }
        public int Capacity {
            get => _capacity;
            private set {
                _capacity = value;
                OnCapacityChanged?.Invoke(_capacity);
            }
        }
        public float RollbackTime => GetRollbackTime();


        private Timer[] _timers;
        private int _capacity;
        private float _rollbackTime;

        public void Init(int capacity, float rollbackTime)
        {
            Capacity = capacity;
            _rollbackTime = rollbackTime;
            _timers = new Timer[capacity];
            for (int i = 0; i < _timers.Length; i++)
            {
                _timers[i] = new Timer();
            }
        }

        public void Shoot()
        {
            if ((Projectile as Laser).IsShoot) return;

            foreach (var timer in _timers)
            {
                if (timer.TimeToFinish > 0) continue;

                Capacity--;
                timer.Start(_rollbackTime);
                timer.OnTimerFinish = () => Capacity++;
                Projectile.Fire();
                break;
            }
        }

        private float GetRollbackTime()
        {
            for (int i = _timers.Length - 1; i >= 0 ; i--)
            {
                if (_timers[i].TimeToFinish > 0) return _timers[i].TimeToFinish;
            }

            return 0.0f;
        }
    }  
}

