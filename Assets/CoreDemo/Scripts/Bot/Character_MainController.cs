using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core.Character;
using Core.StateController;

namespace Core.Character{
    [AddComponentMenu("Core/Character/MainController")]

    public class Character_MainController : MonoBehaviour{
        // 刚体组件
		public Rigidbody2D rigidbodyComponent;
		// 输入组件
		public Character_InputController inputController;
        // 物理组件
        public Character_PhysicsController physicsController;
		// 地面探测组件
		public Character_GroundedTester groundedTester;
        // 渲染组件
        public Character_AnimationController animationController;
        // 相机组件
        public Character_LookController lookController;
        // 朝向组件
        public Character_FlipController flipController;
        // 状态机
        private StateMachine stateMachine;

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
		// Dash CD
        public float dashCD = 4.0f;

        public bool dashOK = true;

        // // 跳跃前容许跳跃持续时间
		// public float lateJumpToleranceDuration = 0.2f;
        // public float canJumpTimeRemaining;
		


        void StateMachineInit(){
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