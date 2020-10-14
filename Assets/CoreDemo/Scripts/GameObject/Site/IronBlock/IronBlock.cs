using Core;
using UnityEngine;

namespace Site{

    
    public class IronBlock : Creature{

        public GroundedTester upTester;


        protected override void StateMachineInit(){
            this.stateMachine = new StateMachine();
            this.stateMachine.addState(new IronBlock_Normal(this));
            this.stateMachine.switchState("normal");
        }

        void Start(){
            StateMachineInit();
        }

        private void FixedUpdate(){
            this.stateMachine.update();
        }
    }
}