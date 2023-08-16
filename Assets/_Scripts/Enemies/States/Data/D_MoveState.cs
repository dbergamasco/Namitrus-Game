using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State data/Move Data")]
public class D_MoveState : ScriptableObject
{
    public float movementSpeed = 3f;
    public float timeBeforeMove = 1f;
}
