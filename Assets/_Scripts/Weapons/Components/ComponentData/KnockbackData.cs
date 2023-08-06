using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class KnockbackData : ComponentData<AttackKnockback>
    {
        protected override void SetComponentDependecy()
        {
            ComponentDependency = typeof(Knockback);
        }
    }
}
