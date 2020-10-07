using UnityEngine;
using System.Collections;

namespace Core.Character
{
	[AddComponentMenu("Core/Character/LookController")]
	public class Wed_LookController : MonoBehaviour 
	{
		// 相机目标
		public Transform cameraTarget;

		// 相机偏移
		private float verticalOffset;
		private float horizontalOffset;
		
		/* 平滑参数 */
		private float smoothTime = 0.0f;
		private float lookVelocity;
		private Vector2 cameraTargetInitialLocal;
		
		public float VerticalOffset{
			get{
				return verticalOffset;
			}
			set{
				verticalOffset = value;
			}
		}

		public float HorizontalOffset{
			get{
				return horizontalOffset;
			}
			set{
				horizontalOffset = value;
			}
		}

		private float CameraTargetHeight{
			get{
				return cameraTarget.localPosition.y;
			}
			set{
				Vector3 cameraTargetPosition = cameraTarget.localPosition;
				cameraTargetPosition.y = value;
				cameraTarget.localPosition = cameraTargetPosition;
			}
		}

		private float CameraTargetWidth{
			get{
				return cameraTarget.localPosition.x;
			}
			set{
				Vector3 cameraTargetPosition = cameraTarget.localPosition;
				cameraTargetPosition.x = value;
				cameraTarget.localPosition = cameraTargetPosition;
			}
		}

		
		private void Awake(){
			cameraTargetInitialLocal = cameraTarget.localPosition;
		}
		
		private void FixedUpdate(){	
			// 平滑处理相机参数变化
			CameraTargetHeight = Mathf.SmoothDamp(CameraTargetHeight, verticalOffset + cameraTargetInitialLocal.x, ref lookVelocity, smoothTime);
			CameraTargetWidth = Mathf.SmoothDamp(CameraTargetWidth, horizontalOffset + cameraTargetInitialLocal.y, ref lookVelocity, smoothTime);
			verticalOffset = 0.0f;
			horizontalOffset = 0.0f;
		}
	}
}
