using System.Collections;
using System.Collections.Generic;
using _Scripts.Weapons.Components.ComponentData;
using _Scripts.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

public class MovementData : ComponentData
{
    [field: SerializeField] public AttackMovement[] AttackData { get; private set; }
}
