using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLookForPlayerStateData", menuName = "Data/State data/Look For Player Data")]
public class D_LookForPlayerState : ScriptableObject
{
    public int amountOfTurns = 2;
    public float timeBetweenTurns = 0.5f;
}
