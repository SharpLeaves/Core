using UnityEngine;
using System.Collections;

namespace Core.Character
{
	[AddComponentMenu("Core/Character/FlipController")]
	public class Wed_FlipController : MonoBehaviour 
	{

		public Transform flipTransform;
		public Wed main;
		public float lookOffset = 0.6f;
		
		private void Update()
		{
			Vector3 localScale = flipTransform.localScale;
			float fHorizontal = main.inputController.Horizontal;
			// 输入左右时逻辑处理
			if(fHorizontal > 0.0f){
				localScale.x = 1.0f;
				
			}
			else if(fHorizontal < 0.0f){
				localScale.x = -1.0f;
				
			}

			if(localScale.x >= 0.0f){
				main.lookController.HorizontalOffset = lookOffset;
			}
			else{
				main.lookController.HorizontalOffset = -lookOffset;
			}
		
			flipTransform.localScale = localScale;
		}
	}
}
