using System.Collections;
using System.Collections.Generic;
using _Scripts.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace _Scripts.Weapons.Components.ComponentData
{
    public class WeaponSpriteData : ComponentData
    {
        [field: SerializeField] public AttackSprites[] AttackData { get; private set; }
    }
}