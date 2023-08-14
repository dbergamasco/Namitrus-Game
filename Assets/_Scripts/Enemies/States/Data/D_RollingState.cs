using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRollingStateData", menuName = "Data/State data/Rolling Data")]
public class D_RollingState : ScriptableObject
{
    public float rollingSpeed = 10f;
    public float rollingTime = 0.2f;
    public float rollingCooldown = 2f;
    public Vector2 rollingAngle;
}
