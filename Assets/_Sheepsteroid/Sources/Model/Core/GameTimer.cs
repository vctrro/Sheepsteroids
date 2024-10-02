using System;
using UnityEngine;

namespace Model
{
    public class GameTimer
    {
        #region Static
        private static float _deltaTime;
        public static event Action OnTimeChanged;
        public static float DeltaTime {
            get => _deltaTime;
            set {
                _deltaTime = value;
                OnTimeChanged?.Invoke();
            }
        }
        #endregion

        public Action OnTimerFinish { get; set; }
        public float TimeToFinish { get; private set; } = 0.0f;

        private float _time;
        private bool _loop;

        public void Start(float time, bool loop = false)
        {
            _loop = loop;
            TimeToFinish = _time = time;
            OnTimeChanged += UpdateTimer;
        }

        public void Stop()
        {
            OnTimeChanged -= UpdateTimer;
            TimeToFinish = 0.0f;
        }

        private void UpdateTimer()
        {
            TimeToFinish -= DeltaTime;
            if (TimeToFinish <= 0)
            {
                OnTimerFinish?.Invoke();

                if (_loop)
                {
                    TimeToFinish = _time;
                }
                else
                {
                    Stop();
                }                
            }
        }
    }
}

