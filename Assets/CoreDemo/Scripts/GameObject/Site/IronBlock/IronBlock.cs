using Core;
using UnityEngine;

namespace Site{
    public class IronBlock : Creature{
        protected override void StateMachineInit(){
            this.stateMachine = new StateMachine();
            this.stateMachine.addState(new IronBlock_Normal(this));
        }

        void Start(){
            StateMachineInit();
        }

        private void FixedUpdate(){
            this.stateMachine.update();
        }
    }
}