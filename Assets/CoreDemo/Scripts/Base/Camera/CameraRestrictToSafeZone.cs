using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Core.Camera
{
	[AddComponentMenu("Core/Camera/CameraRestrictToSafeZone")]
	public class CameraRestrictToSafeZone : MonoBehaviour
	{
		public Transform safeZoneCenter;
		public Vector2 safeZoneSize = new Vector2(1.5f, 1.5f);
		public Vector2 safeZoneOffsetFromTarget = new Vector2(0.0f, 0.0f);
		
		private Vector3 followVelocity;
		
		private void FixedUpdate()
		{
			ConstraintInSafeZone();
		}
		
		private void LateUpdate()
		{
			ConstraintInSafeZone();
		}
		
		private void ConstraintInSafeZone()
		{
			Vector3 position = transform.position;
			
			Vector2 targetPosition = safeZoneCenter.position;
			
			position.x = Mathf.Clamp(position.x, targetPosition.x - safeZoneOffsetFromTarget.x - safeZoneSize.x, targetPosition.x - safeZoneOffsetFromTarget.x + safeZoneSize.x);
			position.y = Mathf.Clamp(position.y, targetPosition.y - safeZoneOffsetFromTarget.y - safeZoneSize.y, targetPosition.y - safeZoneOffsetFromTarget.y + safeZoneSize.y);
			
			transform.position = position;
		}
	}
}