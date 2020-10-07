using UnityEngine;
using Core;


namespace Core.Dog{
    public class DiskTop : Creature{
        protected override void StateMachineInit(){
            stateMachine = new StateMachine();
            stateMachine.addState(new DiskTop_Normal());
            stateMachine.addState(new DiskTop_Active());
            stateMachine.addState(new DiskTop_Moving());
            stateMachine.switchState("moving");
        }
        
        void Start(){


        }

        private void FixedUpdate(){
            this.stateMachine.update();
        }
    }
}