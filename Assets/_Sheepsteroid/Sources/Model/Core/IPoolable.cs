using System;
using UnityEngine.Pool;

namespace Model
{
    public interface IPoolable<T> where T : class
    {
        public void SetPool(ObjectPool<T> pool);
    }
}
