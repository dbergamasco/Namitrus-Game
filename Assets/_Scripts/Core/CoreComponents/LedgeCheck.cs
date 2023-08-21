using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class LedgeCheck : CoreComponents<LedgeCheckData>
    {
        private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
        private Movements movement; 

        private Vector2 center;

        public Vector3 LedgeCheckPosition { get => ledgeCheckPosition; private set => ledgeCheckPosition = value; }
        private Vector3 ledgeCheckPosition;

        protected override void Awake()
        {
            base.Awake();

            center = transform.position;
        }


        protected override void Update()
        {
            base.Update();

            center = transform.position;

            LedgeCheckPosition = CalculateCubePosition(center, data.rangePosition);
        }

        public bool isDetectingLedge()
        {
            if(data.isVertical)
            {
                return Physics2D.Raycast(ledgeCheckPosition, Vector2.down, data.distance, data.detectionLayer);
            }
            else
            {
                return Physics2D.Raycast(ledgeCheckPosition, Vector2.right * Movement.FacingDirection, data.distance, data.detectionLayer);
            }  
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
                Vector3 cubePosition = new Vector3(center.x + data.rangePosition.x * Movement.FacingDirection, center.y - data.rangePosition.y, 0);
                Vector3 cubeSize = new Vector3(data.rangeRadius.x * 2, data.rangeRadius.y * 2, 0);

                Gizmos.color = Color.blue;
                 Gizmos.DrawWireCube(cubePosition, cubeSize);
                if(data.isVertical)
                {
                    Vector3 lineStart = cubePosition - new Vector3(0, data.rangeRadius.y, 0);
                    Vector3 lineEnd = lineStart - new Vector3(0, data.distance, 0);

                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(lineStart, lineEnd);
                }
                else
                {
                    Vector3 lineStart = cubePosition - new Vector3(data.rangeRadius.x * -Movement.FacingDirection, 0, 0);
                    Vector3 lineEnd = lineStart - new Vector3(data.distance * -Movement.FacingDirection, 0 , 0);

                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(lineStart, lineEnd);
                }
            }
        }
        #endregion
    }
}
