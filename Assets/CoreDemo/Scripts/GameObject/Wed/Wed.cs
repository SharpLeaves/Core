using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core.Character;

namespace Core.Character{
    [AddComponentMenu("Core/Character/MainController")]

    public class Wed : Creature{
		// 输入组件
		public Wed_InputController inputController;
        // 相机控制组件
        public Wed_LookController lookController;
        // 朝向组件
        public Wed_FlipController flipController;
        // 装备挂载组件
        public EquipmentController handEquipment;
        public EquipmentController backEquipment;

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
		public float jump = 4.0f;
        // 跳跃重力
        public float jumpGravityScale = 0.8f;
		

        // // 跳跃前容许跳跃持续时间
		// public float lateJumpToleranceDuration = 0.2f;
        // public float canJumpTimeRemaining;
		


        protected override void StateMachineInit(){
            this.stateMachine = new StateMachine();
            this.stateMachine.addState(new Wed_Idle(this));
            this.stateMachine.addState(new Wed_Walk(this));
            this.stateMachine.addState(new Wed_Run(this));
            this.stateMachine.addState(new Wed_Air(this));
            this.stateMachine.addState(new Wed_Crouch(this));
            this.stateMachine.addState(new Wed_LookUp(this));

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