using Core;
using Core.Timer;
using Core.StateController;
using UnityEngine;

namespace Core.Test{
    public class Dash_BackEquipment : IEquipmentBack{
        // Dash CD
        public float dashCD = 4.0f;
        public bool dashOK = true;

        public override string getName(){
            return "Dash";
        }

        public override void function(){
            if(main.GetStateMachine.curState.getName() == "air" && dashOK){
                dashOK = false;
                main.physicsController.addVelocity(main.dashForce * main.flipController.flipTransform.localScale.x, 0);
                TimerManager.instance.addTask(new Task(dashCD, ()=>{
                    dashOK = true;
                }));
            }
        }

        protected override void StateMachineInit(){
            this.stateMachine = new StateMachine();
            this.stateMachine.addState(new DashEquipmentState_Ready(this));
            this.stateMachine.addState(new DashEquipmentState_CD(this));
            this.stateMachine.addState(new DashEquipmentState_Active(this));
            this.stateMachine.switchState("ready");
        }
        void Start(){
            StateMachineInit();
        }
        protected void FixedUpdate(){
            base.FixedUpdate();
            this.stateMachine.update();
        }

    }
}