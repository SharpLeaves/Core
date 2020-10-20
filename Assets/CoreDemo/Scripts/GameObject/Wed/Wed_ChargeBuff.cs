using Core;
using UnityEngine;

namespace Core.Character{

    
    public class Wed_ChargeBuff : MonoBehaviour{

        public AnimatorController animatorController;

        public Wed main;


        private void FixedUpdate(){
            
            if(main.chargeOver){
                switch(main.GetStateMachine.curState.getName()){
                    case "walk":
                        animatorController.play = "charge_walk";
                        break;
                    case "run":
                        animatorController.play = "charge_run";
                        break;
                    case "idle":
                        animatorController.play = "charge_stand";
                        break;
                    case "air":
                        animatorController.play = "charge_jump";
                        break;   
                }    
            }
            else{
                animatorController.play = "charge_void";
            }
        }
    }
}