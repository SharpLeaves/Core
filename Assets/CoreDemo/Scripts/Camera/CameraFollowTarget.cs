using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Core.Camera
{
	[AddComponentMenu("Core/Camera/CameraFollowTarget")]
	public class CameraFollowTarget : MonoBehaviour
	{
		public Transform target;
		public float smoothTime = 0.15f; 
		
		private Vector3 followVelocity;
		
		private void FixedUpdate()
		{		
			Vector3 f3Position = transform.position;
			Vector2 f2TargetPosition = target.position;
			Vector2 f2Position = f3Position;
			
			Vector3 f3SmoothedPosition = Vector3.SmoothDamp(f2Position, f2TargetPosition, ref followVelocity, smoothTime);
			
			f3SmoothedPosition.z = f3Position.z;
			
			transform.position = f3SmoothedPosition;
		}
	}
}