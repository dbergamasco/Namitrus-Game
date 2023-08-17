using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class CollisionSenses : CoreComponents<CollisionSensesData>
    {
        private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
        private Movements movement; 

        private Vector2 center;

        public Vector3 WallCheckPosition { get => wallCheckPosition; private set => wallCheckPosition = value; }
        private Vector3 wallCheckPosition;

        public float WallCheckDistance { get => wallCheckDistance; private set => wallCheckDistance = value; }
        private float wallCheckDistance;

        public LayerMask WhatIsGround { get => whatIsGround; private set => whatIsGround = value; }
        private LayerMask whatIsGround;

        private Vector3 groundCheckPosition;

        protected override void Awake()
        {
            base.Awake();

            center = transform.position;
        }

        protected override void Start()
        {
            base.Start();

            WallCheckDistance = data.wallCheckDistance;
            WhatIsGround = data.whatIsGround;
        }

        protected override void Update()
        {
            base.Update();

            center = transform.position;

            WallCheckPosition = CalculateCubePosition(center, data.wallCheckPosition);
            groundCheckPosition = CalculateCubePosition(center, data.groundCheckPosition);
        }

        public bool isDetectingWall()
        {
            return Physics2D.Raycast(wallCheckPosition, Vector2.right * Movement.FacingDirection, data.wallCheckDistance, data.whatIsGround);
        }

        public bool isDetectingGround()
        {
            return Physics2D.Raycast(groundCheckPosition, Vector2.down, data.groundCheckDistance, data.whatIsGround);
        }

        private Vector3 CalculateCubePosition(Vector2 center, Vector2 rangePosition)
        {
            return new Vector3(center.x + rangePosition.x * Movement.FacingDirection, center.y - rangePosition.y, 0);
        }

        #region Gizmos
        private void OnDrawGizmos()
        {
            if(data.Debug)
            {
                //GroundCheck
                Vector3 groundCheckPosition = new Vector3(center.x + data.groundCheckPosition.x * Movement.FacingDirection, center.y - data.groundCheckPosition.y, 0);
                Vector3 groundCheckCubeSize = new Vector3(data.groundCheckRadius.x * 2, data.groundCheckRadius.y * 2, 0);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireCube(groundCheckPosition, groundCheckCubeSize);
                
                Vector3 groundLineStart = groundCheckPosition - new Vector3(0, data.groundCheckRadius.y, 0);
                Vector3 groundLineEnd = groundLineStart - new Vector3(0, data.groundCheckDistance, 0);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(groundLineStart, groundLineEnd);

                //WallCheck
                Vector3 wallCheckPosition = new Vector3(center.x + data.wallCheckPosition.x * Movement.FacingDirection, center.y - data.wallCheckPosition.y, 0);
                Vector3 wallCheckCubeSize = new Vector3(data.wallCheckRadius.x * 2, data.wallCheckRadius.y * 2, 0);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireCube(wallCheckPosition, wallCheckCubeSize);
                
                Vector3 wallLineStart = wallCheckPosition - new Vector3(data.wallCheckRadius.x * -Movement.FacingDirection, 0, 0);
                Vector3 wallLineEnd = wallLineStart - new Vector3(data.wallCheckDistance * -Movement.FacingDirection, 0 , 0);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(wallLineStart, wallLineEnd);
            }
        }
        #endregion

    }
}

