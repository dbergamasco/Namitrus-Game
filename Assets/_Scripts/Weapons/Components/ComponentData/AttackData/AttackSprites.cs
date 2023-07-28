using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    [Serializable]
    public class AttackSprites : AttackData
    {
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
    }
}