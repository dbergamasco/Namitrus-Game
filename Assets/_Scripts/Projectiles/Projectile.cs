using System.Collections;
using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //private AttackDetails attackDetails;

    private float speed;
    private float travelDistance;
    private float xStartPosition;
    
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float damageRadius;

    private Rigidbody2D rb;

    private bool isGravityOn;

    private bool hasHitGround;

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private Transform damagePosition;

    private float damage;
    private Vector2 knockbackAngle;
    private float knockbackStrength;
    private int direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;

        isGravityOn = false;

        xStartPosition = transform.position.x;
    }

    private void Update()
    {
        if(!hasHitGround)
        {
            if(isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    private void FixedUpdate()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(damagePosition.position, damageRadius, whatIsPlayer);
        Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

        foreach(Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponentInChildren<IDamageable>();
            if(damageable != null)
            {
                damageable.Damage(damage);
                Destroy (gameObject);
            }

            IKnockbackable knockbackable = collider.GetComponentInChildren<IKnockbackable>();
            if(knockbackable != null)
            {
                knockbackable.Knockback(knockbackAngle, knockbackStrength, direction);
            }

        }

        if(groundHit)
        {
            hasHitGround = true;

            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;

            // the arrow is destroyed after a while
            Destroy (gameObject, 3f);
        }

        if(!hasHitGround)
        {
            if(Mathf.Abs(xStartPosition - transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
        }

        
    }

    public void FireProjectile(float speed, float travelDistance, float damage, Vector2 knockbackAngle, float knockbackStrength, int direction)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        this.damage = damage;
        this.knockbackAngle = knockbackAngle;
        this.knockbackStrength = knockbackStrength;
        this.direction = direction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
}
