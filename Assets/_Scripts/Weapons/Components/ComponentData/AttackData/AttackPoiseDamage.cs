using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    [Serializable]
    public class AttackPoiseDamage : AttackData
    {
        [field: SerializeField] public float Amount { get; private set; }
    }
}
