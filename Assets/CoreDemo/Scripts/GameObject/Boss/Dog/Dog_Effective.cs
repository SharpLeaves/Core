using UnityEngine;
using Core;
using Site;

namespace Core.Dog{
    public class Dog_Effective : Effective{
        public Dog main;

        

        protected override void processObjectUpdate(){

            if(main.GetStateMachine.curState.getName() ==  "powerdecrease"){
                foreach(GameObject gameObject in effectedObjects){
                    Creature creature = gameObject.GetComponentInChildren<Creature>();
                    if(creature != null){
                        creature.physicsController.setForce(-this.main.power , 0);
                        if(creature.tag == "Player"){
                            creature.physicsController.setForce(-this.main.power * 5 , 0);
                        }
                            
                    }

                }
            }
        }

        protected override void processObjectExit(GameObject gameObject){
        }

        protected override void processObjectEnter(GameObject gameObject){
        }
    }
}