using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDummy : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject hitParticles;
    
    public void Damage(float amount)
    {
        Debug.Log("Damage received: " + amount);

        // TODO: IMPLEMENT HIT PARTICLES
        //Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
    }
}
