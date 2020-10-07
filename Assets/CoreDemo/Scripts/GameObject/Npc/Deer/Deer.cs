using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core.Character;

namespace Core.Deer{
    public class Deer : Creature{
        public Container container;

        protected override void StateMachineInit(){
            this.stateMachine = new StateMachine();
            this.stateMachine.addState(new Deer_Small(this));
            this.stateMachine.addState(new Deer_Eat(this));
            this.stateMachine.addState(new Deer_Big(this));

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