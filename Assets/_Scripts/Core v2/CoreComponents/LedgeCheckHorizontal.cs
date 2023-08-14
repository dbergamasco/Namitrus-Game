using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class LedgeCheckHorizontal : CoreComponents<LedgeCheckHorizontalData>
    {
        private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
        private Movements movement; 

        private BoxCollider2D boxCollider;
        public Vector3 ledgeCheckPosition;

        public bool isTouchingHorizontalLedge;


        protected override void Awake()
        {
            base.Awake();

        }

        protected override void Start()
        {
            base.Start();

            boxCollider = GetComponentInParent<BoxCollider2D>(); 
        }

        protected override void Update()
        {
            base.Update();
            
            isTouchingHorizontalLedge = TouchingLedgeHorizontalDetection();
        }

        private bool TouchingLedgeHorizontalDetection()
        {
            Vector3 checkPosition = new Vector3(
            boxCollider.bounds.center.x + (boxCollider.bounds.extents.x * Movement.FacingDirection) + (data.ledgeCheckHorizontalDistance * Movement.FacingDirection),
            boxCollider.bounds.center.y + boxCollider.bounds.extents.y,
            boxCollider.bounds.center.z
            );


            return Physics2D.OverlapCircle(checkPosition, 0.1f, data.whatIsGround);
        }

        private void OnDrawGizmos()
        {
            Vector3 checkPosition = new Vector3(
            boxCollider.bounds.center.x + (boxCollider.bounds.extents.x * Movement.FacingDirection) + (data.ledgeCheckHorizontalDistance * Movement.FacingDirection),
            boxCollider.bounds.center.y + boxCollider.bounds.extents.y,
            boxCollider.bounds.center.z
            );

            if(data.Debug)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(checkPosition, 0.1f);
            }
            
        }
    }
}
