using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State data/Melee Attack Data")]
public class D_Melee_AttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10;
    
    public float knockbackStrength = 7f;
    public Vector2 knockbackAngle = Vector2.one;

    public LayerMask whatsIsPlayer;
}
