﻿using UnityEngine;
using System.Collections;

namespace Core.Character
{
	[AddComponentMenu("Core/Character/AnimationController")]
	public class Character_AnimationController : MonoBehaviour 
	{
		public Animator animator;

		private string curPlay;
		private float playSpeed;

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
		
		private bool bOverrideThisFrame;
		public void OverrideThisFrame()
		{
			bOverrideThisFrame = true;
		}
		
		public void Awake(){

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
