using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class MovementData : ComponentData<AttackMovement>
    {
        public MovementData()
        {
            ComponentDependency = typeof(Movement);
        }
    }
}