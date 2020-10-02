using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Core.Physics{
	[AddComponentMenu("Core/Physics")]
	public class GroundedTester : MonoBehaviour {
		// 地面LayerName，用于获取LayerIndex
		public string groundLayerName = "";
		// 地面LayerIndex
		public int groundLayerIndex = 0;
		// 探测器序列
		public List<Transform> groundedTesters;
		// 是否在地面
		private bool bGrounded;
		// 是否在地面
		public bool IsGrounded{
			get{
				return bGrounded;
			}
		}
		// 返回地面LayerIndex
		private int GroundLayer{
			get{
				if(groundLayerName == ""){
					return groundLayerIndex;
				}
				else{
					return LayerMask.NameToLayer(groundLayerName);
				}
			}
		}
		
		private void Update(){
			GroundedTest();
		}
		
		private void GroundedTest(){
			bGrounded = false;
			
			int iGroundLayer = GroundLayer;
			// 定义位置变量
			Vector2 f2Position = transform.position;
			// 遍历地面探测器
			foreach(Transform rGroundTester in groundedTesters){
				Vector2 f2GroundTesterPosition = rGroundTester.position;
				Vector2 f2StartLinecast = f2Position;
				f2StartLinecast.x = f2GroundTesterPosition.x;
				// 检测碰撞
				if(Physics2D.Linecast(f2StartLinecast, f2GroundTesterPosition, 1 << iGroundLayer)){
					bGrounded = true;
				}
			}
		}
	}
}
