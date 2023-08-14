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

        [field: Header("Move Data"), SerializeField, Tooltip("Movespeed in X angle of the entity")] public float moveSpeed;
        [field: Header("Jump Data"), SerializeField, Tooltip("Jump force of the entity jump")] public float jumpForce;
    }
}
