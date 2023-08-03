using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Interfaces
{
    public interface IKnockbackable
    {
        void Knockback(Vector2 angle, float strength, int direction);
    }
}