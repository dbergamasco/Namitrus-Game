using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State data/Melee Attack Data")]
public class D_Melee_AttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 10;
    

    public LayerMask whatsIsPlayer;
}
