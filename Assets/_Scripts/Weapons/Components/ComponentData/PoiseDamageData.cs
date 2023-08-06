using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class PoiseDamageData : ComponentData<AttackPoiseDamage>
    {
        protected override void SetComponentDependecy()
        {
            ComponentDependency = typeof(PoiseDamage);
        }
    }
}
