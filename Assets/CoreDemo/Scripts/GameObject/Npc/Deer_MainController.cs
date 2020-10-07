using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core.Character;
using Core.StateController;

namespace Core.Test{
    public class Deer_MainController : Creature{
        public Container container;

        protected override void StateMachineInit(){
            this.stateMachine = new StateMachine();
            this.stateMachine.addState(new smallState(this));
            this.stateMachine.addState(new bigState(this));
            this.stateMachine.addState(new eatState(this));

            this.stateMachine.switchState("small");
        }

        void Start(){
            StateMachineInit();
        }

        private void FixedUpdate(){
            this.stateMachine.update();
        }
    }
}