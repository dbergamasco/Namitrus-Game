using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class MovementData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(Movements);
        }
    }
}
