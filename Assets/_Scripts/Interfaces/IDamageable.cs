using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Interfaces
{
    public interface IDamageable
    {
        void Damage(float damage);
        float CalcRangeDamage(float damage);
    }
}