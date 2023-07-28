using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    [Serializable]
    public class AttackMovement : AttackData
    {
        [field: SerializeField] public Vector2 Direction { get; private set; }
        [field: SerializeField] public float Velocity { get; private set; }
    }
}