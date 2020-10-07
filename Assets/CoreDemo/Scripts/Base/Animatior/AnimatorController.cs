using UnityEngine;
using System.Collections;

namespace Core.Animation{
	[AddComponentMenu("Core/AnimationController")]
	public class AnimatorController : MonoBehaviour {
		public Animator animator;

		private string curPlay;
		private float playSpeed = 1.0f;

		public string play{
			get{
				return curPlay;
			}
			set{
				curPlay = value;
			}
		}

		public float speed{
			get{
				return playSpeed;
			}
			set{
				playSpeed = value;
			}
		}
		
		private bool overrideThisFrame;
		public void OverrideThisFrame()
		{
			overrideThisFrame = true;
		}

		private void Update(){
			animator.speed = playSpeed;
			animator.Play(curPlay);

		}

		// 自适应动画播放速度		
		private void AdaptAnimationSpeedToMatchVelocity(float a_fNormalSpeedVelocity, float a_fCurrentSpeed){
			float fAnimationSpeedPercent = a_fCurrentSpeed/a_fNormalSpeedVelocity;
			animator.speed = fAnimationSpeedPercent;
		}
	}
}
