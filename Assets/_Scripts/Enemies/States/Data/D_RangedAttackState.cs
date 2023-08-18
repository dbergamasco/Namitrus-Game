using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Data/State data/Ranged Attack Data")]
public class D_RangedAttackState : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 15f;
    public float projectileSpeed = 10f;
    public float projectileTravelDistance = 7f;
    public float knockbackStrength = 2f;
    public Vector2 knockbackAngle = Vector2.one;
}
