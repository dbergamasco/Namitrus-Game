using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Weapons;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    [Serializable]
    public class AttackSprites : AttackData
    {
        [field: SerializeField] public PhaseSprites[] PhaseSprites { get; private set; }
    }
}

[Serializable]
public struct PhaseSprites
{
        [field: SerializeField] public AttackPhases Phase { get; private set; }
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
}