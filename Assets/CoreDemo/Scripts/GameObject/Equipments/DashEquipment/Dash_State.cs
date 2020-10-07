using UnityEngine;
using Core.StateController;
using Core.Timer;

namespace Core.Test{
    public abstract class DashEquipmentState : IState{
        protected Dash_BackEquipment main {get; set;}
    }

    public class DashEquipmentState_Ready : DashEquipmentState{
        public DashEquipmentState_Ready(Dash_BackEquipment equipment){
            main = equipment;
        }
        public override string getName(){
            return "ready";
        }
        public override void onEnter(){
            main.animationController.play = "ready";
        }
        public override void onExit(){

        }
        public override void update(){
            if(main.dashOK == false){
                stateMachine.switchState("active");
            }
        }
    }

    public class DashEquipmentState_CD : DashEquipmentState{
        public DashEquipmentState_CD(Dash_BackEquipment equipment){
            main = equipment;
        }
        public override string getName(){
            return "cd";
        }
        public override void onEnter(){
            main.animationController.play = "cd";
        }
        public override void onExit(){

        }
        public override void update(){
            if(main.dashOK == true){
                stateMachine.switchState("ready");
            }
        }
    }

    public class DashEquipmentState_Active : DashEquipmentState{
        public DashEquipmentState_Active(Dash_BackEquipment equipment){
            main = equipment;
        }
        public override string getName(){
            return "active";
        }
        public override void onEnter(){
            main.animationController.play = "active";
        }
        public override void onExit(){
            
        }
        public override void update(){
            AnimatorStateInfo info =main.animationController.animator.GetCurrentAnimatorStateInfo(0);    

            if (info.normalizedTime >= 1.0f)  {
                stateMachine.switchState("cd");
            }   
        }
    }
}