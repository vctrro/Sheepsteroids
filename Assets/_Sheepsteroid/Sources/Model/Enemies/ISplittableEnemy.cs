using System;
using UnityEngine;

namespace Model
{
    public interface ISplittableEnemy : IEnemy
    {
        public Action<IEnemy> OnSplit { get; set; }
    }
}
