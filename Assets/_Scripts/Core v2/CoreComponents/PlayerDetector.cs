using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

namespace _Scripts.CoreSystem
{
    public class PlayerDetector : CoreComponents<PlayerDetectorData>
    {
        private Movements Movement { get => movement ??= core.GetComponent<Movements>(); }
        private Movements movement;

        private List<Collider2D> closeColliders = new List<Collider2D>();
        private List<Collider2D> longColliders = new List<Collider2D>();

        private Vector2 center;
        public Vector3 closeRangePosition;
        public Vector3 longRangePosition;

        protected override void Awake()
        {
            base.Awake();

            center = transform.position;
        }

        protected override void Update()
        {
            center = transform.position;

            closeRangePosition = CalculateCubePosition(center, data.closeRangePos);
            longRangePosition = CalculateCubePosition(center, data.longRangePos);

        }
        
        public bool hasCloseRangedDetected()
        {
            Vector3 cubeSize = new Vector3(data.closeRangeRadius.x * 2, data.closeRangeRadius.y * 2, 0);

            Collider2D[] collidersArray =
            Physics2D.OverlapBoxAll(closeRangePosition, cubeSize, 0, data.detectionLayer);
            
            closeColliders.Clear();
            
            foreach (Collider2D collider in collidersArray)
            {
                closeColliders.Add(collider);
            }
            return closeColliders.Count > 0;
        }

        public bool hasLongRangedDetected()
        {
            Vector3 cubeSize = new Vector3(data.longRangeRadius.x * 2, data.longRangeRadius.y * 2, 0);

            Collider2D[] collidersArray =
            Physics2D.OverlapBoxAll(longRangePosition, cubeSize, 0, data.detectionLayer);
            
            longColliders.Clear();
            
            foreach (Collider2D collider in collidersArray)
            {
                longColliders.Add(collider);
            }
            return longColliders.Count > 0;
        }

        private Vector3 CalculateCubePosition(Vector2 center, Vector2 rangePosition)
        {
            return new Vector3(center.x + rangePosition.x * Movement.FacingDirection, center.y - rangePosition.y, 0);
        }

        #region Gizmos 
        private void OnDrawGizmos()
        {
            center = transform.position;

            if(data.Debug)
            {
                Vector3 closeRangeCubePosition = new Vector3(center.x + data.closeRangePos.x * Movement.FacingDirection, center.y - data.closeRangePos.y, 0);
                Vector3 closeRangeCubeSize = new Vector3(data.closeRangeRadius.x * 2, data.closeRangeRadius.y * 2, 0);

                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(closeRangeCubePosition, closeRangeCubeSize);

                Vector3 longRangeCubePosition = new Vector3(center.x + data.longRangePos.x * Movement.FacingDirection, center.y - data.longRangePos.y, 0);
                Vector3 longRangeCubeSize = new Vector3(data.longRangeRadius.x * 2, data.longRangeRadius.y * 2, 0);

                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(longRangeCubePosition, longRangeCubeSize);
            }
        }
        #endregion
    }
}
