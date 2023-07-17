using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDummy : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth; 
    [SerializeField] private GameObject hitParticles;

    private float currentHealth;

    private Player player;

    private Rigidbody2D rb;
    private Animator anim;

    private int playerFacingDirection;
    private bool playerOnLeft;
    
    private void Start() {
        currentHealth = maxHealth;

        player = GameObject.Find("Player").GetComponent<Player>();

        

        anim  = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Damage(float amount)
    {
        currentHealth -= amount;
        playerFacingDirection = player.Core.Movement.FacingDirection;
        
        if (playerFacingDirection == 1)
        {
            playerOnLeft = true;
        }
        else
        {
            playerOnLeft = false;
        }

        anim.SetBool("playerOnLeft", playerOnLeft);
        anim.SetTrigger("damage");

        // TODO: IMPLEMENT HIT PARTICLES
        Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
    }
}
