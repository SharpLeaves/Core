using UnityEngine;

namespace Core.Equipment{
    public abstract class DashEquipmentBack_State : IState{
        protected DashEquipmentBack main {get; set;}
    }

    public class DashEquipmentBack_Ready : DashEquipmentBack_State{
        public DashEquipmentBack_Ready(DashEquipmentBack equipment){
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

    public class DashEquipmentBack_CD : DashEquipmentBack_State{
        public DashEquipmentBack_CD(DashEquipmentBack equipment){
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

    public class DashEquipmentBack_Active : DashEquipmentBack_State{
        public DashEquipmentBack_Active(DashEquipmentBack equipment){
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