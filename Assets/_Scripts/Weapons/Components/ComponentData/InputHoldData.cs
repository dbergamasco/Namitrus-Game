using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class InputHoldData : ComponentData
    {
        protected override void SetComponentDependecy()
        {
            ComponentDependency = typeof(InputHold);
        }
    }
}
