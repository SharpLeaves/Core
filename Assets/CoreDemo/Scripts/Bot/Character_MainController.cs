using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core.Character;
using Core.StateController;

namespace Core.Character{
    [AddComponentMenu("Core/Character/MainController")]

    public class Character_MainController : Creature{
		// 输入组件
		public Character_InputController inputController;
        // 相机控制组件
        public Character_LookController lookController;
        // 朝向组件
        public Character_FlipController flipController;

        /* 角色动作参数 */
		// 行走增量
		public float walkForce = 10f;
		// 奔跑增量
		public float runForce = 50f;
        // 浮空增量
        public float airForce = 30f;
        // 冲刺速度
        public float dashForce = 20f;
        // 最小行走速度
        public float walkMinSpeed = 0.2f;
        // 最小跑步速度
        public float runMinSpeed = 1f;
		// 跳跃初速
		public float jump = 2.0f;
        // 跳跃重力
        public float jumpGravityScale = 0.8f;
		

        // // 跳跃前容许跳跃持续时间
		// public float lateJumpToleranceDuration = 0.2f;
        // public float canJumpTimeRemaining;
		


        protected override void StateMachineInit(){
            this.stateMachine = new StateMachine();
            this.stateMachine.addState(new IdleState(this));
            this.stateMachine.addState(new WalkState(this));
            this.stateMachine.addState(new RunState(this));
            this.stateMachine.addState(new AirState(this));
            this.stateMachine.addState(new CrouchState(this));
            this.stateMachine.addState(new LookUpState(this));

            this.stateMachine.switchState("idle");
        }

        void Start(){
            StateMachineInit();
        }

        private void FixedUpdate(){
            this.stateMachine.update();
            // Debug.Log(this.stateMachine.curState.getName());
        }
    }
}