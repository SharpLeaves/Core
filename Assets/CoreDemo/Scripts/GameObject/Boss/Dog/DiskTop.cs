using UnityEngine;
using Core;
using Core.Character;


namespace Core.Dog{
    public class DiskTop : Creature{
        public Wed aimAt;
        public bool active = false;
        public float power = 50.0f;

        protected override void StateMachineInit(){
            stateMachine = new StateMachine();
            stateMachine.addState(new DiskTop_Normal(this));
            stateMachine.addState(new DiskTop_Active(this));
            stateMachine.addState(new DiskTop_Moving(this));
            stateMachine.switchState("normal");
        }
        
        void Start(){
            StateMachineInit();

        }

        private void FixedUpdate(){
            this.stateMachine.update();
        }
    }
}