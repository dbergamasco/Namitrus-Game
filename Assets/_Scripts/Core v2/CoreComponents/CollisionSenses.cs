using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class CollisionSenses : CoreComponents<CollisionSensesData>
    {
        private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
        private Movements movement; 

        private BoxCollider2D boxCollider;

        public bool isGrounded;
        public bool isTouchingWall;

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

            isGrounded = TouchingGroundDetection();
            isTouchingWall = TouchingWallDetection();
        }

        private bool TouchingGroundDetection()
        {
            Vector3 checkPosition = new Vector3(
            boxCollider.bounds.center.x,
            boxCollider.bounds.center.y - boxCollider.bounds.extents.y,
            boxCollider.bounds.center.z
            );

            return Physics2D.OverlapCircle(checkPosition, 0.1f, data.whatIsGround);
        }

        private bool TouchingWallDetection()
        {
            Vector3 checkPosition = new Vector3(
            boxCollider.bounds.center.x + (boxCollider.bounds.extents.x * Movement.FacingDirection),
            boxCollider.bounds.center.y,
            boxCollider.bounds.center.z
            );

            return Physics2D.OverlapCircle(checkPosition, 0.1f, data.whatIsGround);
        }

        #region Gizmos
        private void OnDrawGizmos()
        {
            Vector3 wallCheckPosition = new Vector3(
            boxCollider.bounds.center.x + (boxCollider.bounds.extents.x * Movement.FacingDirection),
            boxCollider.bounds.center.y,
            boxCollider.bounds.center.z
            );

            if(data.Debug)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(wallCheckPosition, 0.1f);
            }

            Vector3 groundCheckPosition = new Vector3(
            boxCollider.bounds.center.x,
            boxCollider.bounds.center.y - boxCollider.bounds.extents.y,
            boxCollider.bounds.center.z
            );

            if(data.Debug)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawSphere(groundCheckPosition, 0.1f);
            }
        }
        #endregion
    }
}

